using com.goldsprite.GSTools.EssentialAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Events;


public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Movement movement;
    [SerializeField] private float deadZone = 0.2f;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    public void SetTarget(GameObject gameObject)
    {
        target = gameObject;
    }

    public void ClearTarget()
    {
        target = null;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 directionToPlayer = (target.transform.position - transform.position);
            var distance = Vector2.Distance(target.transform.position, transform.position);
            if (distance < deadZone)
            {
                movement.SetMoveDirection(Vector2.zero);
                return;
            }
            movement.SetMoveDirection(directionToPlayer);
        }
        else
        {
            movement.SetMoveDirection(Vector2.zero);
        }
    }
}
