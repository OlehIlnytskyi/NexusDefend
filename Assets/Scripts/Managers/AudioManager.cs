using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singletone

    public static AudioManager main { get; private set; }

    private void Awake()
    {
        if (main != null && main != this)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }

    #endregion

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundsSource;

    [SerializeField] private AudioClip mainMenuMusic;

    private void Start()
    {
        PlayMainMenuMusic();
    }

    public void PlayNextMusic(AudioClip music)
    {
        if (musicSource.clip.name != music.name)
            StartCoroutine(SwapMusic(musicSource.volume, music));
    }

    public void PlaySound(AudioClip sound)
    {
        soundsSource.PlayOneShot(sound);
    }

    private IEnumerator SwapMusic(float startVolume, AudioClip nextMusic)
    {
        if (musicSource.clip != nextMusic)
        {
            if (musicSource.volume <= 0)
            {
                musicSource.clip = nextMusic;
                musicSource.Play();
            }

            musicSource.volume -= 0.01f;
            yield return new WaitForSeconds(0.1f);
            yield return SwapMusic(startVolume, nextMusic);
        }
        else
        {
            if (musicSource.volume < startVolume)
            {
                musicSource.volume += 0.01f;
                yield return new WaitForSeconds(0.1f);
                yield return SwapMusic(startVolume, nextMusic);
            }

            yield break;
        }
    }

    public void PlayMainMenuMusic()
    {
        StartCoroutine(SwapMusic(musicSource.volume, mainMenuMusic));
    }
}