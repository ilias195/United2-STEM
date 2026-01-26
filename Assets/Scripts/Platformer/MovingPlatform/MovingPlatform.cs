using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform[] points;

    private int i;
    private Rigidbody2D rb;
    private int currentIndex = 0; //nummer van het punt waar we nu naartoe bewegen


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
        if (points == null || points.Length < 2) return;

        Transform target = points[currentIndex];

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.fixedDeltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            currentIndex++;
            if (currentIndex >= points.Length) // ga terug naar punt 0
                currentIndex = 0;
        }
    }

   


}
