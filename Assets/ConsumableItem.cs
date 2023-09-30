using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class ConsumableItem : MonoBehaviour
{
    public Item item;
    [SerializeField] private UnityEvent onConsume;
    [SerializeField] private float secondsBeforeDestroy = 1f;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.sprite;
    }

    public void Consume()
    {
        spriteRenderer.sprite = null;
        StartCoroutine(ConsumeCoroutine());
    }

    private IEnumerator ConsumeCoroutine()
    {
        onConsume.Invoke();
        yield return new WaitForSeconds(secondsBeforeDestroy);
        Destroy(this);
    }
}
