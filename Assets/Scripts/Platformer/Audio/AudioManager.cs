using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioCurrent;

    private AudioSource audioSource;
    [SerializeField] private float volume = 1f;
    private void Awake()
    {
        // Singleton (maar simpel)
        if (audioCurrent == null)
        {
            audioCurrent = this;
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip, volume);
    }

    public void SetVolume(float value)
    {
        volume = value;
    }

    public float GetVolume()
    {
        return volume;
    }
}
