using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Item item;
    public Text itemCountText;

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
        itemCountText.text = newItem.itemCount.ToString();
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void setItemCountText(int n){
        itemCountText.text = n.ToString();
    }
}
