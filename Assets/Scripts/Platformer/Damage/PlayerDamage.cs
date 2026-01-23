using System.Collections;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int damageAmount = 25;
    [SerializeField] private float forceBackPower = 10f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Damage")) return;

        playerHealth.TakeDamage(damageAmount);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, forceBackPower);
        StartCoroutine(BlinkRed());
    }

    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
