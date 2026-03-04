
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    [SerializeField] private int _healAmount = 25;
    [SerializeField] private AudioClip _healSound;   
    [SerializeField] private float _volume = 1f;     

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();


        if (player != null)
        {
            Debug.Log("Heal picked up");
            player.Heal(_healAmount);

            //  speel geluid af op positie van object
            AudioSource.PlayClipAtPoint(_healSound, transform.position, _volume);

            Destroy(other.gameObject);
        }
    }
}
