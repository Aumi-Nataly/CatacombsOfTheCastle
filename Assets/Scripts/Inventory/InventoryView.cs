using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class InventoryView : MonoBehaviour
{
    [SerializeField] 
    private Transform slotsParent;
    [SerializeField]
    private InventorySlotUI slotPrefab;

    [SerializeField]
    private List<InvetoryModel> listItems = new();

    private List<InventorySlotUI> slots = new();


    private void Start()
    {
        Init();
    }

    public void Init()
    {
        for (int i = 0; i < listItems.Count; i++)
        {
            var slot = Instantiate(slotPrefab, slotsParent);
           
            slot.SetItem(listItems[i].ItemIcon, 5, listItems[i].ItemType);
            slots.Add(slot);
        }
    }



    //public void Open()
    //{
    //    panel.SetActive(true);

    //    Cursor.visible = true;
    //    Cursor.lockState = CursorLockMode.None;
    //}

    //public void Close()
    //{
    //    panel.SetActive(false);

    //    Cursor.visible = false;
    //    Cursor.lockState = CursorLockMode.Locked;
    //}
}
