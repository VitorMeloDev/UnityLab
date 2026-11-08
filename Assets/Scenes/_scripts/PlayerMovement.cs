using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpForce = 6f;

    private Rigidbody2D  rb;
    private Actions input;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = new Actions();
    }

    private void OnEnable()
    {
        input.Gameplay.Enable();

        input.Gameplay.Jump.performed += _ => Jump();

        input.Gameplay.Move.performed += ctx =>
            movement = ctx.ReadValue<Vector2>();

        input.Gameplay.Move.canceled += _ =>
            movement = Vector2.zero;
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(movement.x, movement.y);
        rb.linearVelocityX = movement.x * speed;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnDisable()
    {
        input.Gameplay.Disable();
    }
}