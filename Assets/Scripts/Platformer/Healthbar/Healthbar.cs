using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    [Header("UI")]
    public Image fillImage;
    public TextMeshProUGUI healthText;  

    [Header("Color")]
    public Gradient gradient;

    private float maxHealth;

    public void SetMaxHealth(float health)
    {
        maxHealth = health;
        fillImage.fillAmount = 1f;
        fillImage.color = gradient.Evaluate(1f);

        healthText.text = health + " / " + health;
    }

    public void SetHealth(float health)
    {
        float normalized = health / maxHealth;
        fillImage.fillAmount = normalized;
        fillImage.color = gradient.Evaluate(normalized);

        healthText.text = health + " / " + maxHealth;
    }
}
