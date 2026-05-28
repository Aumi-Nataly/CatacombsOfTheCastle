using UnityEngine;

public class PauseScreen : MonoBehaviour
{

    [SerializeField] 
    private GameObject pausePanel;

    public void ViewPauseScreen(bool view)
    {
        Cursor.visible = view;
        Cursor.lockState = view ? CursorLockMode.None : CursorLockMode.Locked;
        
        pausePanel.SetActive(view);
        Time.timeScale = view ? 0f : 1f;
    }
}
