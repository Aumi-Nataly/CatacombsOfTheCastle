using UnityEngine;

public class PauseScreen : MonoBehaviour
{

    [SerializeField] 
    private GameObject pausePanel;

    public void ViewPauseScreen(bool view)
    {
        Debug.Log($"ViewPauseScreen {view}");

        // Проверка на null для pausePanel
        if (pausePanel == null)
        {
            Debug.LogError("pausePanel не назначен в инспекторе!");
            return;
        }


        Cursor.visible = view;
        Cursor.lockState = view ? CursorLockMode.None : CursorLockMode.Locked;
        
        pausePanel.SetActive(view);
        Time.timeScale = view ? 0f : 1f;
    }

    public void ResumeGame()
    {
        ViewPauseScreen(false);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        // Например: SceneManager.LoadScene("MainMenu");
    }
}
