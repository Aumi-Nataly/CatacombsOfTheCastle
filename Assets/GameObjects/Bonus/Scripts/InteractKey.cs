using UnityEngine;
using VContainer;

public class InteractKey : MonoBehaviour, IInterable
{
    [SerializeField]
    private int Id;

    private  IInventoryService _inventoryService;
    private MusicManager _musicManager;

    [Inject]
    public void Construct(IInventoryService inventoryService, MusicManager musicManager)
    {
        _inventoryService = inventoryService;
        _musicManager = musicManager;
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
        _musicManager.PlayGetBonusSound();
        _inventoryService.Add(ItemType.Key, 1);
        gameObject.SetActive(false);
        
        PlayerPrefs.SetInt("key_" + Id.ToString(), 1);
        PlayerPrefs.Save();
    }
}
