using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    [SerializeField] private float secondBeforeDestroy;
    [SerializeField] private GameObject gameobjectToDestroy;

    public void Destroy()
    {
        StartCoroutine(DestroingCoroutine());
    }

    private IEnumerator DestroingCoroutine()
    {
        yield return new WaitForSeconds(secondBeforeDestroy);
        Destroy(gameobjectToDestroy);
    }
}
