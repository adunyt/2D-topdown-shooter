using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private GameObject target;

    public float lookAtSpeed = 5.0f; // Adjust this value as needed

    private void Update()
    {
        if (target != null)
        {
            // Calculate the direction from the enemy to the target
            Vector3 directionToTarget = target.transform.position - transform.position;

            if (directionToTarget != Vector3.zero)
            {
                // Create a rotation based on the direction to the target
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToTarget);

                // Smoothly rotate the enemy towards the target
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, lookAtSpeed * Time.deltaTime);
            }

        }
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    public void RemoveTarget()
    {
        this.target = null;
    }
}
