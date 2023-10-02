using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemCount> items = new List<ItemCount>();
    [SerializeField] private UnityEvent onItemsChange;

    [System.Serializable]
    public class ItemCount
    {
        public Item item;
        public int count;
    }

    // Singleton instance
    private static Inventory instance;

    public static Inventory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Inventory>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("Inventory");
                    instance = obj.AddComponent<Inventory>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void AddItem(Item item, int count = 1)
    {
        ItemCount existingItem = FindItem(item);

        if (existingItem != null && item.stackable)
        {
            existingItem.count += count;
        }
        else
        {
            items.Add(new ItemCount { item = item, count = count });
        }

        onItemsChange.Invoke();
    }

    public ReadOnlyCollection<ItemCount> GetAllItems()
    {
        return items.AsReadOnly();
    }

    public void RemoveItem(Item item, int count = 1)
    {
        ItemCount existingItem = FindItem(item);

        if (existingItem != null && existingItem.count > count)
        {
            existingItem.count -= count;
        }
        else
        {
            items.Remove(existingItem);
        }

        onItemsChange.Invoke();
    }

    private ItemCount FindItem(Item item)
    {
        return items.Find(i => i.item == item);
    }

    // Method to convert inventory data to InventoryData structure
    public InventoryData ToInventoryData()
    {
        var inventoryData = new InventoryData();

        foreach (var itemCount in items) // Change the variable name to itemCount
        {
            var itemData = new ItemData
            {
                itemName = itemCount.item.name, // Use itemCount here
                count = itemCount.count
            };
            inventoryData.itemsDataList.Add(itemData);
        }
        return inventoryData;
    }


    // Method to load inventory data from InventoryData structure
    public void FromInventoryData(InventoryData inventoryData)
    {
        items.Clear();

        foreach (var itemData in inventoryData.itemsDataList)
        {
            var item = Resources.Load<Item>("Items/" + itemData.itemName);
            print("Items/" + itemData.itemName); // Adjust the path as needed

            if (item != null)
            {
                items.Add(new ItemCount { item = item, count = itemData.count });
            }
        }

        onItemsChange.Invoke();
    }
}
