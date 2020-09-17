using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    public Item item;
    public Text itemCountText;
    
    GameObject equipSlotsParent;
    EqipSlot[] equipSlots;
    GameObject Tap_sell;

    GameObject noticeFrame;
    GameObject noticeFrame_text;
    GameObject noticeFrame_InputField;

    public void OnPointerClick(PointerEventData eventData){

        if(item != null && Tap_sell != null){
            if(Tap_sell.GetComponent<Toggle>().isOn){
                noticeFrame.SetActive(true);
                noticeFrame_text = GameObject.Find("NoticeFrame_text");
                noticeFrame_InputField = GameObject.Find("NoticeFrame_InputField");
                noticeFrame_text.GetComponent<Text>().text = "\"" + item.itemName + "\"";
                ItemSellingNoticeFrameFunc.item = this.item;

                int tmpCount = int.Parse(noticeFrame_InputField.GetComponent<InputField>().text);
                if (tmpCount == null) tmpCount = 1;

                ItemSellingNoticeFrameFunc.itemCount = tmpCount;
            }
        }
    
        //우클릭일경우
        if(eventData.button == PointerEventData.InputButton.Right){
            if(item!=null && item.itemType == Item.ItemType.equip){
                
                for (int i = 0; i<equipSlots.Length; i++){
                    if(equipSlots[i].item == item) return; //같은 장비로 바꿀려 하면 무시.
                }                
                int thisItemCount = int.Parse(itemCountText.text);
                if(thisItemCount > 1) item.IncreaseItemCount(-1); //장비가 1개 이상이라면 갯수 감산
                else {
                    Item searchedItem = Inventory.instance.itemList.Find(x => x.itemID == item.itemID);
                    Inventory.instance.itemList.Remove(searchedItem); //아이템 목록에서 잠시 삭제 
                    ClearSlot();
                } //현재 슬롯에서 제외하고 장비 슬롯으로 옮기기 - 아이템 추가와 충돌할 수 있음. (문제가 생긴다면 스크립트 같이 점검하기)

                if (item.equipType == Item.EquipType.weapon) equipSlots[0].SetEquip(item, this);
                if (item.equipType == Item.EquipType.top) equipSlots[1].SetEquip(item, this);
                if (item.equipType == Item.EquipType.pants) equipSlots[2].SetEquip(item, this);
                if (item.equipType == Item.EquipType.shoes) equipSlots[3].SetEquip(item, this);

            }
        }
    }

    void Start()
    {
        icon.enabled = false;
        equipSlotsParent = GameObject.Find("EquipSlots");
        equipSlots = equipSlotsParent.GetComponentsInChildren<EqipSlot>();
        Tap_sell = GameObject.Find("Tap_sell");
        noticeFrame = ItemSellingNoticeFrameFunc.returnNoticeFrameGameObject();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        Debug.Log("아이콘 업데이트" + gameObject.name);
        icon.sprite = item.itemIcon;
        icon.enabled = true;
        //itemCountText.text = newItem.returnItemCount().ToString();

        // 아이템 종류에 따른 색 변환을 하려면 다음 주석 해제
        // if(newItem.itemType == Item.ItemType.equip){
        //     this.gameObject.GetComponent<Image>().color = new Color(100/255f,202/255f,225/255f); //장비라면 배경 색 변환
        //     //Debug.Log(this.gameObject.GetComponent<Image>());
        // }
    }

    public void ClearSlot()
    {
        //this.gameObject.GetComponent<Image>().color = Color.white;
        item = null;
        itemCountText.text = "";
        icon.enabled = false;
    }

    void Update(){
        if(item != null && item.returnItemCount() >= 1) itemCountText.text = item.returnItemCount().ToString();
    }
}
