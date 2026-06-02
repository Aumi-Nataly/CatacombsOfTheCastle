using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private string NextLvlName;
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
