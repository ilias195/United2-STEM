using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int coins;
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;

    public float MoveInput { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate; // extra smooth
    }

    private void Update()
    {
        MoveInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(MoveInput * moveSpeed, rb.linearVelocity.y);
    }
}

