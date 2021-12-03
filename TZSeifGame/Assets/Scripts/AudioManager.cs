using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    [Header("Аудиоклипы")]
    public AudioClip switchShtift;
    public AudioClip unlockShtift;
    public AudioClip seifOpen;
    public AudioClip pruzhinaOtskok;
    public AudioClip DeactivLocker;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void AudioPlay(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
