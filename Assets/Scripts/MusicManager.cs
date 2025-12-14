using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip music;
    public float startTime = 12f;

    private void Start()
    {
        musicSource = GetComponent<AudioSource>();

        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.time = startTime;
        musicSource.Play();
    }
}
