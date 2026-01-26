using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform[] points;
    [SerializeField] private int damage = 25;

    private int i;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private AudioClip hitClip;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (points.Length > 0)
        {
            transform.position = points[0].position;
        }
    }

    private void Update()
    {
        if (points.Length < 2) return;

        if (Vector2.Distance(transform.position, points[i].position) < 0.25f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(
            transform.position,
            points[i].position,
            speed * Time.deltaTime
        );

        spriteRenderer.flipX =
            (points[i].position.x - transform.position.x) > 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);

            if (AudioManager.audioCurrent != null && hitClip != null)
            {
                AudioManager.audioCurrent.PlaySound(hitClip);
            }
        }
    }



}
