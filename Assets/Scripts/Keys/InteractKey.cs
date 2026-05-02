

using UnityEngine;
using VContainer;

public class InteractKey : MonoBehaviour, IInterable
{
    private  IInventoryService _inventoryService;

    [Inject]
    public void Construct(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
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
    }
}
