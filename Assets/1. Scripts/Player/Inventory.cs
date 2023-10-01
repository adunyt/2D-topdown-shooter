using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> itemsList = new();
    [SerializeField] private List<int> itemsCount = new();
    [SerializeField] private UnityEvent onItemsChange;

    public void AddItem(Item item, ushort count = 1)
    {
        int itemIndex = itemsList.IndexOf(item);
        if (itemIndex != -1 && item.stackable)
        {
            itemsCount[itemIndex] += count;
        }
        else
        {
            itemsList.Add(item);
            itemsCount.Add(count);
        }
        onItemsChange.Invoke();
    }

    public (ReadOnlyCollection<Item>, ReadOnlyCollection<int>) GetAllItems()
    {
        return (itemsList.AsReadOnly(), itemsCount.AsReadOnly());
    }

    public void RemoveItem(Item item, ushort count = 1)
    {
        int itemIndex = itemsList.IndexOf(item);
        if (itemIndex != -1 && itemsCount[itemIndex] > count)
        {
            itemsCount[itemIndex] -= count;
        }
        else
        {
            itemsList.RemoveAt(itemIndex);
            itemsCount.RemoveAt(itemIndex);
        }
        onItemsChange.Invoke();
    }

    // Method to convert inventory data to InventoryData structure
    public InventoryData ToInventoryData()
    {
        var inventoryData = new InventoryData();
        for (int i = 0; i < itemsList.Count; i++)
        {
            var itemData = new ItemData
            {
                itemName = itemsList[i].name,
                count = itemsCount[i]
            };
            inventoryData.itemsDataList.Add(itemData);
        }
        return inventoryData;
    }

    // Method to load inventory data from InventoryData structure
    public void FromInventoryData(InventoryData inventoryData)
    {
        itemsList.Clear();
        itemsCount.Clear();

        foreach (var itemData in inventoryData.itemsDataList)
        {
            var item = Resources.Load<Item>("Items/" + itemData.itemName);
            print("Items/" + itemData.itemName);// Adjust the path as needed
            if (item != null)
            {
                itemsList.Add(item);
                itemsCount.Add(itemData.count);
            }
        }

        onItemsChange.Invoke();
    }
}
