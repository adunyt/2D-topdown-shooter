using com.goldsprite.GSTools.EssentialAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsToDrop : MonoBehaviour
{
    [SerializeField] Item item;

    [SerializeField] private bool random;
    [SerializeField] private List<Item> randomItems = new List<Item>();

    public void Drop()
    {
        Item itemToSpawn;
        if (!random)
        {
            itemToSpawn = item;
        }
        else
        {
            itemToSpawn = randomItems[Random.Range(0, randomItems.Count)];
        }
        Instantiate(itemToSpawn, transform.position, Quaternion.identity);
    }
}
