using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;


public class InteractDoor : MonoBehaviour, IInterable
{
    [SerializeField]
    private string NextLvlName;
    
    [SerializeField]
    private GameObject childTransform;
    Light lightComponent;
    private IInventoryService _inventoryService;
    private MusicManager _musicManager;

    [Inject]
    public void Construct(IInventoryService inventoryService, MusicManager musicManager)
    {
        _inventoryService = inventoryService;
        _musicManager = musicManager;
    }


    void Awake()
    {     
        lightComponent = childTransform?.GetComponent<Light>();
        lightComponent.enabled = false;
    }

    public void ChangeLight(bool enable)
    {
        lightComponent.enabled = enable;
    }

    public string GetInteractPromt()
    {
        return "";
    }

    public void Interact()
    {
        _inventoryService.WriteToFile();
        _musicManager.StopBackgroundMusic();
        LoaderScene.NextSceneName = NextLvlName;
        SceneManager.LoadScene("LoadingScene");
    }
}
