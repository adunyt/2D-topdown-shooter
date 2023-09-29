using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAdapter : MonoBehaviour
{
    [SerializeField] private Entity entity;

    public void Hit(GameObject gameObject)
    {
        if (!gameObject.TryGetComponent(out Entity enemy))
            return;

        entity.Attack(enemy);
    }
}
