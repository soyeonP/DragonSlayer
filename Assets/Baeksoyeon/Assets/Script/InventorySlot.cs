using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Item item;

    void Start()
    {
        icon.enabled = false;
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        Debug.Log("아이콘 업데이트" + gameObject.name);
        icon.sprite = item.itemIcon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }


}
