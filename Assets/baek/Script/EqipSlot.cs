using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EqipSlot : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    public Item item;
    bool hasItemOver1 = false;
    InventorySlot originalSlot;

    public Transform itemsParent;
     InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        icon.enabled = false;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    public void OnPointerClick(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Right && item != null){
            
            if (Inventory.instance.IsSameItemExist(item)) hasItemOver1 = true; //같은 장비가 아이템창에 남아있는가?
            if (hasItemOver1 && originalSlot!=null){ //같은 장비가 아이템창에 남아있는 상태일때
                Inventory.instance.itemList.Find(x => x.itemID == item.itemID).IncreaseItemCount(1); //아이템 갯수 다시 늘리고 UI업데이트
            }else{
                Inventory.instance.Add(new Item(item.itemID, item.itemName, item.itemDescripton, item.itemIcon, item.itemType, item.equipType), 1);
                }
                DisArmEquip(); //장비 해제
            }
        }

    public void SetEquip(Item equip, InventorySlot slot = null)
    {
        item = equip;
        icon.sprite = item.itemIcon;
        icon.enabled = true;
        originalSlot = slot;

        // if(equip.itemType == Item.ItemType.equip){
        //     this.gameObject.GetComponent<Image>().color = new Color(100/255f,202/255f,225/255f); //장비라면 배경 색 변환
        //     //Debug.Log(this.gameObject.GetComponent<Image>());
        // }
    }

    public void DisArmEquip(){
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
