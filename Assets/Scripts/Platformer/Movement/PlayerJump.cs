using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int extraJumpValue = 1;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

   

    private Rigidbody2D rb;
    private bool isGrounded;
    private int extraJumps;

    [Header("Input Settings")]
    [SerializeField] private KeyCode keyboardJumpKey = KeyCode.Space;
    [SerializeField] private KeyCode arcadeJumpKey = KeyCode.JoystickButton0;

    [SerializeField] private AudioClip jumpClip;
    public bool IsGrounded => isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        extraJumps = extraJumpValue;
        
    }

    private void Update()
    {
        if (isGrounded)
        {
            extraJumps = extraJumpValue;
        }

        if (Input.GetKeyDown(keyboardJumpKey) || Input.GetKeyDown(arcadeJumpKey))
        {
            if (isGrounded || extraJumps > 0)
            {
              
                if (AudioManager.audioCurrent != null && jumpClip != null)
                {
                    AudioManager.audioCurrent.PlaySound(jumpClip);
                }
                else
                {
                    Debug.LogWarning("Jump sound niet afgespeeld (AudioManager of clip is null)");
                }

              
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

                if (!isGrounded)
                {
                    extraJumps--;
                }
            }
        }
    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }

   
}
