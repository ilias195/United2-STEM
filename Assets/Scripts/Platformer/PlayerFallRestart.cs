using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerFallRestart : MonoBehaviour
{
    [SerializeField] private float fallY = 0f;
    [SerializeField] private AudioClip fallCip;

    private void Update()
    {
        if (transform.position.y < fallY)
        {
            if (AudioManager.audioCurrent != null && fallCip != null)
            {
                AudioManager.audioCurrent.PlaySound(fallCip);

            }

            Restart();
        }
    }

    private void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
