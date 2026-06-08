using UnityEngine;
using VContainer;

public class BackgroundLevelMusic : MonoBehaviour
{
    private MusicManager _musicManager;

    [Inject]
    public void Construct(MusicManager musicManager)
    {
        _musicManager = musicManager;
    }

    private void Start()
    {
        _musicManager.PlayBackgroundLevelMusic();
    }
}
