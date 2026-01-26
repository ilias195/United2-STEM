using UnityEngine;
using TMPro;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerCoin;
    [SerializeField] private TextMeshProUGUI coinText;

    private void Update()
    {
        coinText.text = "coins: " + playerCoin.coins;
    }
}
