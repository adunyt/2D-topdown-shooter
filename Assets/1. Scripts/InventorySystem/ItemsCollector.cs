using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollector : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private string itemsTag;


    private void Awake()
    {
        inventory = Inventory.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var itemGameobject = collision.gameObject;
        if (itemGameobject.CompareTag(itemsTag))
        {
            if (itemGameobject.TryGetComponent(out ConsumableItem consumableItem))
            {
                inventory.AddItem(consumableItem.item);
                consumableItem.Consume();
            }
            else
            {
                Debug.LogWarning("No ConsumableItem component in item!");
            }
        }
    }
}
