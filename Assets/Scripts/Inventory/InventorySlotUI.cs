using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{

    public void SetItem(Sprite sprite, int count, ItemType itemType)
    {
        var img = GetComponent<Image>();
        img.sprite = sprite;

        var button = GetComponent<Button>();
        var textComponent = button.GetComponentInChildren<TMP_Text>();
        textComponent.text = count.ToString();

    }


    public void OnClick()
    {
        Debug.Log("Clicked item: ");
    }
}
