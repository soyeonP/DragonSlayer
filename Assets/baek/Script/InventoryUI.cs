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

             if (i < inventory.itemList.Count)
            {
                slots[i].AddItem(inventory.itemList[i]);
                //if(inventory.itemList[i].itemCount > 1) slots[i].setItemCountText(inventory.itemList[i].itemCount); //1개 이상이라면 수 표시
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
