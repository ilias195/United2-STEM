using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform[] points;

    private int i;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.position = points[0].position;
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(rb.position, points[i].position) < 0.01f)
        {
            i++;
            if (i == points.Length)
                i = 0;
        }

        rb.MovePosition(
            Vector2.MoveTowards(rb.position, points[i].position, speed * Time.fixedDeltaTime)
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SetParentNextFrame(collision.transform));
        }
    }

    private IEnumerator SetParentNextFrame(Transform player)
    {
        yield return null; // wacht 1 frame
        player.SetParent(transform);
    }


}
