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
    private IInventoryService _inventoryService;
    private MusicManager _musicManager;

    [Inject]
    public void Construct(IInputSystem inputSystem, IInventoryService inventoryService, MusicManager musicManager)
    {
        _inputSystem = inputSystem;
        _inventoryService = inventoryService;
        _musicManager = musicManager;
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
        _musicManager.PlayMenuClick();
        ViewPauseScreen();
    }
    public void GoToMainMenu()
    {
        _inventoryService.ResetFile();
        Time.timeScale = 1f;
        LoaderScene.NextSceneName = "MainMenuScene";
        _inputSystem.AddAttack();
        _musicManager.StopBackgroundMusic();
        _musicManager.PlayMenuClick();
        SceneManager.LoadScene("LoadingScene");
    }
}
