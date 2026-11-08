using UnityEngine;
using FMOD.Studio;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpForce = 6f;

    private Rigidbody2D  rb;
    private Actions input;
    public Vector2 movement;
    private EventInstance playerFootsteps;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = new Actions();
    }

    void Start()
    {
        playerFootsteps = AudioManager.instance.CreateEventInstance(FMODEvents.instance.playerFootsteps);
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
        rb.linearVelocityX = movement.x * speed;

        
        if (rb.linearVelocityX != 0f)
        {
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);
            if (playbackState != PLAYBACK_STATE.PLAYING)
            {
                playerFootsteps.start();
            }
        }
        else
        {
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
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