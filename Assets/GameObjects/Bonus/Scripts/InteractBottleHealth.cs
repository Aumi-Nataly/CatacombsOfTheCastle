using UnityEngine;
using VContainer;

public class InteractBottleHealth : MonoBehaviour, IInterable
{
    [SerializeField]
    private int Id;

    private IInventoryService _inventoryService;

    public void ChangeLight(bool enable)
    {
       
    }

    [Inject]
    public void Construct(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    public string GetInteractPromt()
    {
        return null;
    }

    public void Interact()
    {
        _inventoryService.Add(ItemType.HealthBottle, 1);
        gameObject.SetActive(false);

        PlayerPrefs.SetInt("bottlehealth_" + Id.ToString(), 1);
        PlayerPrefs.Save();
    }

    void Start()
    {
        //если разрабатывать игру с возможностью возвращения на предыдущий уровень,
        // то собранные предметы повторно не отображать
        if (PlayerPrefs.GetInt("bottlehealth_" + Id.ToString(), 0) == 1)
        {
            gameObject.SetActive(false);
        }
    }
}
