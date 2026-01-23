using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;

    public float MoveInput { get; private set; }//andere script mogen deze waarde lezen maar, alleen dit script mag het aanpassen

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(MoveInput * moveSpeed, rb.linearVelocity.y);
    }
}

