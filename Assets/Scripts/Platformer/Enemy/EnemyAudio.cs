using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [SerializeField] private AudioClip hitClip;

    public void PlayHitSound()
    {
        if (AudioManager.audioCurrent != null && hitClip != null)
        {
            AudioManager.audioCurrent.PlaySound(hitClip);
        }
    }
}
