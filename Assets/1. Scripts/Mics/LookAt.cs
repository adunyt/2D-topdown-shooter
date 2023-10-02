using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private bool smooth;
    [SerializeField] private float smoothSpeed = 5.0f;

    private void Update()
    {
        if (target != null)
        {
            Vector3 directionToTarget = target.transform.position - transform.position;

            if (directionToTarget != Vector3.zero)
            {
                // Calculate the rotation without creating a new Quaternion
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToTarget);

                // Use Slerp for smooth rotation
                if (smooth)
                {
                    targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
                }

                transform.rotation = targetRotation;
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        print("changing");
        this.target = target;
    }

    public void RemoveTarget()
    {
        print("remove");
        this.target = null;
    }
}
