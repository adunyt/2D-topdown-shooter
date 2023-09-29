using com.goldsprite.GSTools.EssentialAttributes;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float maxSpeed = 5f; // Maximum chase speed
    [SerializeField] private float acceleration = 2f; // Acceleration rate
    [SerializeField] private float deceleration = 4f; // Deceleration rate

    [SerializeField] [ReadOnly] private Vector2 moveDirection = Vector2.zero;
    [SerializeField][ReadOnly] private float currentSpeed = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        if (moveDirection != Vector2.zero)
        {
            // Apply acceleration
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, Time.deltaTime * acceleration);
        }
        else
        {
            // Apply deceleration

            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, Time.deltaTime * deceleration);
        }

        // Set the velocity based on the current speed and direction
        
        rb.velocity = moveDirection * currentSpeed;
    }

    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
    }
}
