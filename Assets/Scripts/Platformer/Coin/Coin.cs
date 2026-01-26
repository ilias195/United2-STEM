using UnityEngine;

public class Coin : MonoBehaviour 
{
    [SerializeField] private AudioClip coinClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Coin picked up");

            PlayerMovement playerCoin = collision.GetComponent<PlayerMovement>();
            if (playerCoin != null)
            {
                playerCoin.coins++;
                

                if (AudioManager.audioCurrent != null && coinClip != null)
                {
                    AudioManager.audioCurrent.PlaySound(coinClip);
                   
                }
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("PlayerMovement script ontbreekt!");
            }
        }

    }

    
}
