using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;
    InventorySlot[] slots;
   
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChagedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }   

    void UpdateUI()
    {
        Debug.Log("Updating UI, Slot size: " + slots.Length);
        for (int i=0; i< slots.Length; i++)
        {   
             if (i < inventory.itemList.Count) //해당 슬롯이 비어있거나 업데이트가 덜 되었다면
            {
                slots[i].AddItem(inventory.itemList[i]);
                //if(inventory.itemList[i].returnItemCount() >= 1) slots[i].setItemCountText(inventory.itemList[i].returnItemCount()); //1개 이상이라면 수 표시
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
