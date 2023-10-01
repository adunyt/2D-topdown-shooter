using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceDrawer : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemDrawer itemDrawerPrefab; // Reference to your ItemDrawer prefab
    private List<ItemDrawer> itemDrawers = new List<ItemDrawer>();

    private void Awake()
    {
        // Initialize the UI based on the current inventory
        UpdateUI();
    }

    public void UpdateUI()
    {
        // Get the current items and counts from the inventory
        var (items, itemsCount) = inventory.GetAllItems();

        for (int i = 0; i < items.Count; i++)
        {
            ItemDrawer itemDrawer;
            if (i < itemDrawers.Count)
            {
                // Item drawer already exists; enable it
                itemDrawer = itemDrawers[i];
                itemDrawer.gameObject.SetActive(true);
            }
            else
            {
                // Item drawer doesn't exist; instantiate and add it
                itemDrawer = InstantiateItemDrawer(i);
                itemDrawers.Add(itemDrawer);
            }

            // Set the item and count in the item drawer
            itemDrawer.SetItem(items[i], itemsCount[i]);
        }

        // Disable any extra item drawers that are not needed
        for (int i = items.Count; i < itemDrawers.Count; i++)
        {
            itemDrawers[i].gameObject.SetActive(false);
        }
    }

    private ItemDrawer InstantiateItemDrawer(int index)
    {
        // Instantiate a new item drawer and set its parent to the current panel
        ItemDrawer itemDrawer = Instantiate(itemDrawerPrefab, transform);
        itemDrawer.name = $"ItemDrawer_{index}"; // Optional: Rename for clarity
        return itemDrawer;
    }

}
