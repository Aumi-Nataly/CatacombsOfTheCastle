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
    private GameObject Player;
    [SerializeField]
    private List<InvetoryModel> listItems = new();

    private bool HasOpened;

    private List<InventorySlotUI> slots = new();


    private IInventoryService _inventoryService;

    [Inject]
    public void Construct(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    private void Start()
    {
        var pl = Player.GetComponent<PlayerMovement>();
        pl.OnInventoryClick += OpenCloseInventory;

        Init();
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

       // Cursor.visible = res;
       // Cursor.lockState = CursorLockMode.None;
    }

    //public void Close()
    //{
    //    panel.SetActive(false);

    //    Cursor.visible = false;
    //    Cursor.lockState = CursorLockMode.Locked;
    //}
}
