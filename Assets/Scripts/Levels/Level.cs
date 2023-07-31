using UnityEngine;

public class Level : MonoBehaviour
{
    public Nexus blueNexus;
    public Nexus redNexus;

    [SerializeField] private AudioClip levelMusic;

    private void Start()
    {
        AudioManager.main.PlayNextMusic(levelMusic);
    }
}