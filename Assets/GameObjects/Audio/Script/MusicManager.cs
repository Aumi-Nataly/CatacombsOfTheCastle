using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioMenuClip;

    [SerializeField]
    private AudioClip audioLevelClip;

    private AudioSource MenuSource;
    private AudioSource LevelSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        MenuSource = gameObject.AddComponent<AudioSource>();
        MenuSource.clip = audioMenuClip;
        MenuSource.loop = true;
        MenuSource.volume = 0.8f;

        LevelSource = gameObject.AddComponent<AudioSource>();
        LevelSource.clip = audioLevelClip;
        MenuSource.loop = true;
        LevelSource.volume = 0.5f;
    }

    public void PlayMusicMenu()
    {
        if (MenuSource != null && audioMenuClip != null && !MenuSource.isPlaying)
        {
            MenuSource.Play(); 
        }
    }

    public void PlayBackgroundLevelMusic()
    {
        if (LevelSource != null && audioLevelClip != null && !LevelSource.isPlaying)
        {
            LevelSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        AudioSource currentPlay = MenuSource.isPlaying ? MenuSource :
                                (LevelSource.isPlaying ? LevelSource : null);

        if (currentPlay != null)
        {
            currentPlay.Stop();
        }
    }
}
