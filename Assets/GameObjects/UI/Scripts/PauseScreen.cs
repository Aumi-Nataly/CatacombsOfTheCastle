using UnityEngine;

public class PauseScreen : MonoBehaviour
{

    [SerializeField] 
    private GameObject pausePanel;

    [SerializeField]
    private GameObject Player;

    private PlayerMovement pl;
    private bool HasOpened;

    private void Start()
    {
        pl = Player.GetComponent<PlayerMovement>();
        pl.OnPauseClick += ViewPauseScreen;

    }

    private void OnDestroy()
    {
        pl.OnInventoryClick -= ViewPauseScreen;
    }

    public void ViewPauseScreen()
    {
        Debug.Log($"ViewPauseScreen {HasOpened}");

        // Проверка на null для pausePanel
        if (pausePanel == null)
        {
            Debug.LogError("pausePanel не назначен в инспекторе!");
            return;
        }


        Cursor.visible = HasOpened;
        Cursor.lockState = HasOpened ? CursorLockMode.None : CursorLockMode.Locked;
        
        pausePanel.SetActive(HasOpened);
        Time.timeScale = HasOpened ? 0f : 1f;
        HasOpened = !HasOpened;
    }

    public void ResumeGame()
    {
        ViewPauseScreen();
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        // Например: SceneManager.LoadScene("MainMenu");
    }
}
