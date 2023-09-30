using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceDrawer : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    private List<ItemDrawer> itemDrawers = new();

    private void Awake()
    {
        itemDrawers.Clear();
        itemDrawers = new(GetComponentsInChildren<ItemDrawer>());
        UpdateUI();
    }

    public void UpdateUI()
    {
        var (items, itemsCount) = inventory.GetAllItems();
        if (itemDrawers.Count < items.Count)
        {
            Debug.LogWarning("More items then ItemDrawers! Skipping overflowing items");
        }
        for (int i = 0; i < itemDrawers.Count && i < items.Count; i++)
        {
            var itemDrawer = itemDrawers[i];
            itemDrawer.SetItem(items[i], itemsCount[i]);
        }

    }
}
