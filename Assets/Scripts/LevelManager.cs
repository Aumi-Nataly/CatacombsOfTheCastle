using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text txtLevelName;

    [SerializeField]
    private string LevelName;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;

        txtLevelName.text = LevelName;
    }
 
}
