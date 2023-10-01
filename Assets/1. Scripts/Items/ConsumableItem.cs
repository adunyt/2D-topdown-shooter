using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ConsumableItem : MonoBehaviour
{
    public Item item;
    [SerializeField] private UnityEvent onConsume;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (item.sprite == null)
        {
            Debug.LogWarning("No sprite in item!");
            return;
        }
        spriteRenderer.sprite = item.sprite;
    }

    public void Consume()
    {
        spriteRenderer.sprite = null;
        onConsume?.Invoke();
    }
}
