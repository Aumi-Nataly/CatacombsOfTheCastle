using UnityEngine;
using VContainer;

public class MusicMainMenu : MonoBehaviour
{
    private MusicManager _musicManager;

    [Inject]
    public void Construct(MusicManager musicManager)
    {
        _musicManager = musicManager;
    }

    private void Start()
    {
        _musicManager.PlayMusicMenu();
    }
}
