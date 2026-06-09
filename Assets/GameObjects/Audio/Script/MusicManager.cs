using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioMenuClip;

    [SerializeField]
    private AudioClip audioLevelClip;

    [SerializeField]
    private AudioClip runPlayerSoundClip;

    [SerializeField]
    private AudioClip jumpPlayerSoundClip;

    [SerializeField]
    private AudioClip getBonusSoundClip;

    [SerializeField]
    private AudioClip menuClickClip;

    [SerializeField]
    private AudioClip BulletClip;

    [SerializeField]
    private AudioClip EnemyGrowlClip;

    [SerializeField]
    private AudioClip GameOverClip;

    private AudioSource MenuSource;
    private AudioSource LevelSource;
    private AudioSource RunPlayerSource;
    private AudioSource JumpPlayerSource;
    private AudioSource GetBonusSource;
    private AudioSource MenuClickSource;
    private AudioSource BulletSound;
    private AudioSource EnemyGrowlSound;
    private AudioSource GameOverSound;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        MenuSource = gameObject.AddComponent<AudioSource>();
        MenuSource.clip = audioMenuClip;
        MenuSource.loop = true;
        MenuSource.volume = 0.5f;

        LevelSource = gameObject.AddComponent<AudioSource>();
        LevelSource.clip = audioLevelClip;
        MenuSource.loop = true;
        LevelSource.volume = 0.5f;

        RunPlayerSource = gameObject.AddComponent<AudioSource>();
        RunPlayerSource.clip = runPlayerSoundClip;
        RunPlayerSource.loop = true;
        RunPlayerSource.volume = 0.7f;
        RunPlayerSource.pitch = 1.7f;

        JumpPlayerSource = gameObject.AddComponent<AudioSource>();
        JumpPlayerSource.clip = jumpPlayerSoundClip;
        JumpPlayerSource.volume = 0.7f;

        GetBonusSource = gameObject.AddComponent<AudioSource>();
        GetBonusSource.clip = getBonusSoundClip;
        GetBonusSource.volume = 0.7f;

        MenuClickSource = gameObject.AddComponent<AudioSource>();
        MenuClickSource.clip = menuClickClip;

        BulletSound = gameObject.AddComponent<AudioSource>();
        BulletSound.clip = BulletClip;
        BulletSound.volume = 0.7f;

        EnemyGrowlSound = gameObject.AddComponent<AudioSource>();
        EnemyGrowlSound.clip = EnemyGrowlClip;
        EnemyGrowlSound.volume = 0.7f;

        GameOverSound = gameObject.AddComponent<AudioSource>();
        GameOverSound.clip = GameOverClip;
        GameOverSound.volume = 0.7f;

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

    public void PlayRunPlayerSound(float speed, bool isGround)
    {
        if (RunPlayerSource != null && runPlayerSoundClip != null)
        {
            float currentSpeed = Mathf.Abs(speed);
            bool shouldPlay = currentSpeed > 0.1 && isGround;

            if (shouldPlay && !RunPlayerSource.isPlaying)
            {
                RunPlayerSource.Play();
            }
            else if (!shouldPlay && RunPlayerSource.isPlaying)
            {
                RunPlayerSource.Stop();
            }

        }
    }

    public void PlayJumpPlayerSound()
    {
        if (JumpPlayerSource != null && jumpPlayerSoundClip != null)
        {
            JumpPlayerSource.PlayOneShot(jumpPlayerSoundClip);
        }
    }

    public void PlayGetBonusSound()
    {
        if (GetBonusSource != null && getBonusSoundClip != null)
        {
            GetBonusSource.PlayOneShot(getBonusSoundClip);
        }
    }

    public void PlayMenuClick()
    {
        if (MenuClickSource != null && menuClickClip != null)
        {
            MenuClickSource.PlayOneShot(menuClickClip);
        }
    }

    public void PlayBulletSound()
    {
        if (BulletSound != null && BulletClip != null)
        {
            BulletSound.PlayOneShot(BulletClip);
        }
    }

    public void PlayEnemyGrowlSound()
    {
        if (EnemyGrowlSound != null && EnemyGrowlClip != null)
        {
            EnemyGrowlSound.PlayOneShot(EnemyGrowlClip);
        }
    }

    public void PlayGameOverSound()
    {
        if (GameOverSound != null && GameOverClip != null)
        {
            GameOverSound.PlayOneShot(GameOverClip);
        }
    }
}
