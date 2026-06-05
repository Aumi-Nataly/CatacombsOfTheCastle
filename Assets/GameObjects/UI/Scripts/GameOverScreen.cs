using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnerEnemy;

    [SerializeField]
    private GameObject gameOverPanel;


    [SerializeField]
    private GameObject Player;

    private SpawnerEnemy sp;
    private TMP_Text gameOverText;
    private Health health;

    private IInputSystem _inputSystem;

    [Inject]
    public void Construct(IInputSystem inputSystem)
    {
        _inputSystem = inputSystem;
    }


    public void Start()
    {
        gameOverText = gameOverPanel.GetComponentInChildren<TMP_Text>();

        if (spawnerEnemy != null)
        {
            sp = spawnerEnemy.GetComponent<SpawnerEnemy>();
            sp.OnGameOver += ResultOfGame;
        }

        if (Player != null)
        {
            health = Player.GetComponentInChildren<Health>();
            health.OnGameOver += ResultOfGame;
        }
    }

    private void ResultOfGame(GameOverType gameType)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _inputSystem.ResetAttack();

        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        gameOverText.text = gameType == GameOverType.Win ? "Выиграли!" : "Проиграли...";
    }

    public void GoToMainMenu()
    {
        Debug.Log("В меню!!!!!!!!!!!!");
        Time.timeScale = 1f;
        LoaderScene.NextSceneName = "MainMenuScene";
        _inputSystem.AddAttack();
        SceneManager.LoadScene("LoadingScene");
    }
}
