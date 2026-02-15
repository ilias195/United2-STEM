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

    private bool shieldActive = false;

    [SerializeField] private Healthbar healthbar;
    private void Start()
    {
        currentHealth = maxHealth;

        healthbar.SetMaxHealth(maxHealth);
    }
    public void Heal(int amount)
    {
        if (isDead) { return; }

        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        healthbar.SetHealth(currentHealth);
    }

    public void ActivateShield(float duration)
    {
        StartCoroutine(ShieldRoutine(duration));
    }

    private System.Collections.IEnumerator ShieldRoutine(float duration) //Een Coroutine is een functie die kan wachten zonder het spel te stoppen
    {
        shieldActive = true;
        yield return new WaitForSeconds(duration); //wacht paar  seconden zonder het spel te stoppen
        shieldActive = false;
    }
    public void TakeDamage(int amount)
    {
        if (isDead) return;

        if (shieldActive)
            amount /= 2; // halve damage

        currentHealth -= amount;
        Debug.Log("Player HP: " + currentHealth);

        healthbar.SetHealth(currentHealth); //update UI

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
