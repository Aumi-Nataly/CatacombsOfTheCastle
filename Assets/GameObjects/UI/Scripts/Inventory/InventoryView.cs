using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class InventoryView : MonoBehaviour
{
    [SerializeField] 
    private Transform slotsParent;
    [SerializeField]
    private InventorySlotUI slotPrefab;

    [SerializeField]
    private List<InvetoryModel> listItems = new();

    private bool HasOpened;

    private List<InventorySlotUI> slots = new();

    private IInventoryService _inventoryService;
    private IInputSystem _inputSystem;

    [Inject]
    public void Construct(IInventoryService inventoryService, IInputSystem inputSystem)
    {
        _inventoryService = inventoryService;
        _inputSystem = inputSystem;
    }

    private void Start()
    {
        _inputSystem.OnInventoryClick += OpenCloseInventory;
        Init();
    }

    private void OnDestroy()
    {
        _inputSystem.OnInventoryClick -= OpenCloseInventory;
    }

    public void Init()
    {
        for (int i = 0; i < listItems.Count; i++)
        {
            var slot = Instantiate(slotPrefab, slotsParent);
            int count = _inventoryService.GetСoncreteItem(listItems[i].ItemType);
            slot.SetItem(listItems[i].ItemIcon, count, listItems[i].ItemType);
            slots.Add(slot);
        }
    }


    private void UpdDataInventory()
    {
        foreach (var sl in slots)
        {
            int count = _inventoryService.GetСoncreteItem(sl.ItemType);
            sl.UpdateItem(count);
        }
    }


    public void OpenCloseInventory()
    {
        var res = HasOpened ? false : true;

        if (res)
        {
            UpdDataInventory();
        }

        slotsParent.gameObject.SetActive(res);
        HasOpened = !HasOpened;

    }
}
