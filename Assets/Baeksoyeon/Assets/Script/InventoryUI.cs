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
                Debug.Log("Add Item");
                slots[i].AddItem(inventory.itemList[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
