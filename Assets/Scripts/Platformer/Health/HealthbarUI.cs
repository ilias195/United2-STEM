using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthbarUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image fillImage;
    [SerializeField] private TextMeshProUGUI healthText;
    private void Update()
    {
        float current = playerHealth.CurrentHealth;
        float max = playerHealth.MaxHealth;

        fillImage.fillAmount = current / max;//Dus deze regel zorgt dat de balk visueel meebeweegt met je HP.

        healthText.text = current + " / " + max;
    }   
}
