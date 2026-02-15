using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    [SerializeField] private int _healAmount = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
         PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.Heal(_healAmount);
            Destroy(gameObject);
        }
    }
}
