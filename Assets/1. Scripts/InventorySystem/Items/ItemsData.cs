using System.Collections.Generic;

[System.Serializable]
public class InventoryData
{
    public List<ItemData> itemsDataList = new List<ItemData>();
}

[System.Serializable]
public class ItemData
{
    public string itemName;
    public int count;
}