using com.goldsprite.GSTools.EssentialAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunController : MonoBehaviour
{
    [SerializeField][ReadOnly] private GameObject hittenObject;
    [SerializeField] private UnityEvent<GameObject> onHit;

    public void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), Mathf.Infinity, 1 << 3);

        if (hit.collider != null)
        {
            hittenObject = hit.collider.gameObject;
            onHit.Invoke(hittenObject);
        }
        else
        {
            hittenObject = null;
        }
    }
}
