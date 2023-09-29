using com.goldsprite.GSTools.EssentialAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsToDrop : MonoBehaviour
{
    [SerializeField] GameObject item;

    [SerializeField] private bool random;
    [SerializeField] private List<GameObject> randomItems = new List<GameObject>();

    public void Drop()
    {
        GameObject itemToSpawn;
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
