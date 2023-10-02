using UnityEngine;
using System.IO;

public class InventoryManager : MonoBehaviour
{
    private Inventory inventory;

    private void Awake()
    {
        inventory = Inventory.Instance;
        LoadInventory();
        Application.quitting += Application_quitting;
    }

    private void Application_quitting()
    {
        SaveInventory();
    }

    // Save inventory data to a JSON file in the game's persistent data path
    public void SaveInventory()
    {
        var inventoryData = inventory.ToInventoryData();
        string json = JsonUtility.ToJson(inventoryData);

        // Construct the full save path in the persistent data path
        string savePath = Path.Combine(Application.persistentDataPath, "inventory.json");
        print($"Saving to {savePath}");
        File.WriteAllText(savePath, json);
    }

    // Load inventory data from a JSON file in the game's persistent data path
    public void LoadInventory()
    {
        // Construct the full load path in the persistent data path
        string loadPath = Path.Combine(Application.persistentDataPath, "inventory.json");

        if (File.Exists(loadPath))
        {
            string json = File.ReadAllText(loadPath);
            var inventoryData = JsonUtility.FromJson<InventoryData>(json);
            print($"Load from {loadPath}");
            inventory.FromInventoryData(inventoryData);
        }
    }
}
