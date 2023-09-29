using com.goldsprite.GSTools.EssentialAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float deceleration = 5f;
    [SerializeField] private UnityEvent onFire;
    [Header("Debug")]
    [SerializeField] [ReadOnly] private bool isInputActive = false;
    
    private Rigidbody2D rb;
    private Vector2 move;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue inputValue)
    {
        move = inputValue.Get<Vector2>().normalized;
        isInputActive = move != Vector2.zero;
    }

    public void OnFire()
    {
        onFire.Invoke();
    }

    private void FixedUpdate()
    {
        if (isInputActive)
        {
            // Apply acceleration
            rb.velocity += acceleration * Time.fixedDeltaTime * move.normalized;

            // Limit the velocity to the max speed
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
        else
        {
            // Apply deceleration when no input is active
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.fixedDeltaTime * deceleration);
        }
    }
}
