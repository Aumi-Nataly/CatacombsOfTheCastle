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

    [Inject]
    public void Construct(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
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
        LoaderScene.NextSceneName = NextLvlName;
        SceneManager.LoadScene("LoadingScene");
    }
}
