using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private string NextLvlName;

    void Awake()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

    }

    public void OnNewGame()
    {
        LoaderScene.NextSceneName = NextLvlName;
        SceneManager.LoadScene("LoadingScene");
    }

    public void OnExitGame()
    {
        Application.Quit();
    }
}
