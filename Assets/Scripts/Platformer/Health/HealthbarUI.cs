using UnityEngine;
using UnityEngine.UI;

public class HealthbarUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image fillImage;

    private void Update()
    {
        fillImage.fillAmount = playerHealth.CurrentHealth / (float)playerHealth.MaxHealth;
    }
}
