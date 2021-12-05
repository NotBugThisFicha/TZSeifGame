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

    public static AudioManager Instance;    

    private void Awake()                   
    {
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AudioPlay(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
