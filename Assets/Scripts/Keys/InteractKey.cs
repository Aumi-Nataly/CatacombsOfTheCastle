using UnityEngine;
using VContainer;

public class InteractKey : MonoBehaviour, IInterable
{
    [SerializeField]
    private int Id;

    private  IInventoryService _inventoryService;

    [Inject]
    public void Construct(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    void Start()
    {
        //  Скрыть ключ, если он уже был подобран
        if (PlayerPrefs.GetInt("key_" + Id.ToString(), 0) == 1)
        {
            gameObject.SetActive(false); 
        }
    }

    public void ChangeLight(bool enable)
    {

    }

    public string GetInteractPromt()
    {
        return null;
    }

    public void Interact()
    {
        _inventoryService.Add(ItemType.Key, 1);
        gameObject.SetActive(false);
        
        PlayerPrefs.SetInt("key_" + Id.ToString(), 1);
        PlayerPrefs.Save();
    }
}
