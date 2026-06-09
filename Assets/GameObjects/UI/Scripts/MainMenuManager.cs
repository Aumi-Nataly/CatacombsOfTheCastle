using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private string NextLvlName;

    private MusicManager _musicManager;

    [Inject]
    public void Construct(MusicManager musicManager)
    {
        _musicManager = musicManager;
    }


    void Awake()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

    }

    public void OnNewGame()
    {
        _musicManager.StopBackgroundMusic();
        _musicManager.PlayMenuClick();
        LoaderScene.NextSceneName = NextLvlName;
        SceneManager.LoadScene("LoadingScene");
    }

    public void OnExitGame()
    {
        _musicManager.StopBackgroundMusic();
        _musicManager.PlayMenuClick();
        Application.Quit();
    }
}
