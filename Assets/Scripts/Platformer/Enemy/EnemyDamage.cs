using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int damage = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);

            EnemyAudio enemyAudio = GetComponent<EnemyAudio>();
            if (enemyAudio != null)
            {
                enemyAudio.PlayHitSound();
            }
        }
    }
}
