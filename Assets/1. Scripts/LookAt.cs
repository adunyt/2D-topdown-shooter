using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private void Update()
    {
        if (target == null)
            return;

        transform.right = target.transform.position - transform.position;
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
