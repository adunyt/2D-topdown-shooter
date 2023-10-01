using com.goldsprite.GSTools.EssentialAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsToDrop : MonoBehaviour
{
    public enum SpawnType
    {
        First,
        Random
    }

    [SerializeField] private SpawnType spawnType;
    [SerializeField] private List<Item> itemsToSpawn = new();

    public void Drop()
    {
        switch (spawnType)
        {
            case SpawnType.First:
                SpawnConsumableItem(itemsToSpawn[0]);
                break;
            case SpawnType.Random:
                SpawnConsumableItem(itemsToSpawn[Random.Range(0, itemsToSpawn.Count)]);
                break;
            default:
                return;
        }
    }

    private void SpawnConsumableItem(Item item)
    {
        var consumableItem = new GameObject
        {
            tag = "Items"
        };
        consumableItem.transform.position = transform.position;
        var collider = consumableItem.AddComponent<CircleCollider2D>();
        collider.radius = 0.3f;
        collider.isTrigger = true;
        consumableItem.AddComponent<ConsumableItem>().item = item;
    }
}
