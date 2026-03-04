using UnityEngine;
using TMPro;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerCoin;
    [SerializeField] private TextMeshProUGUI coinText;

    [SerializeField] private string labelName = "coins";

    private void Update()
    {
        coinText.text = labelName + ": " + playerCoin.coins;
    }
}
