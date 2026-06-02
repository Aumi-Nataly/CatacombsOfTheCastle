using UnityEngine;
using VContainer;

public class PauseScreen : MonoBehaviour
{

    [SerializeField] 
    private GameObject pausePanel;

    private bool HasOpened;
    private IInputSystem _inputSystem;

    [Inject]
    public void Construct( IInputSystem inputSystem)
    {
        _inputSystem = inputSystem;
    }

    private void Start()
    {
        _inputSystem.OnPauseClick += ViewPauseScreen;
    }

    private void OnDestroy()
    {
        _inputSystem.OnPauseClick -= ViewPauseScreen;
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
