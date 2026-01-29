using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    private bool isDead = false;

    [SerializeField] private Healthbar healthbar;
    private void Start()
    {
        currentHealth = maxHealth;

        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        Debug.Log("Player HP: " + currentHealth);

        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("Player is dead");

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
