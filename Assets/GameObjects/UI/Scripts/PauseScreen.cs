using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using VContainer;

public class PauseScreen : MonoBehaviour
{

    [SerializeField] 
    private GameObject pausePanel;

    private bool HasOpened;
    private IInputSystem _inputSystem;

    [Inject]
    public void Construct(IInputSystem inputSystem)
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
        if (pausePanel == null)
        {
            Debug.LogError("pausePanel не назначен в инспекторе!");
            return;
        }

        if (HasOpened)
        {
            _inputSystem.ResetAttack();
        }
        else 
        {
            _inputSystem.AddAttack();
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
        LoaderScene.NextSceneName = "MainMenuScene";
        SceneManager.LoadScene("LoadingScene");
    }
}
