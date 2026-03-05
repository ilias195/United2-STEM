using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int coins;
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    [Header("Input Settings")]
    [SerializeField] private KeyCode moveLeftKey = KeyCode.A;
    [SerializeField] private KeyCode moveRightKey = KeyCode.D;
    [SerializeField] private KeyCode arcadeLeftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode arcadeRightKey = KeyCode.RightArrow;
    public float MoveInput { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate; // extra smooth
    }

    private void Update()
    {
        MoveInput = 0f;

        if (Input.GetKey(moveLeftKey) || Input.GetKey(arcadeLeftKey))
        {
            MoveInput = -1f;
        }

        if (Input.GetKey(moveRightKey) || Input.GetKey(arcadeRightKey))
        {
            MoveInput = 1f;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(MoveInput * moveSpeed, rb.linearVelocity.y);
    }
}


