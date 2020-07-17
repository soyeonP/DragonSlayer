using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")] //프로젝트-에셋 창에 아이템 파일을 생성할 수 있게 해줍니다.
public class Item : ScriptableObject //상속 - 스크립팅 가능한 오브젝트. 상세 설명 메뉴얼 참고.
{

    public int itemID;
    public string itemName;
    [TextArea(3,5)] public string itemDescripton;
    public Sprite itemIcon;
    public ItemType itemType;
    public EquipType equipType;
    int itemCount = 0;

   //public string itemSpriteFileName; //아이템 스프라이트 파일 이름

    public enum EquipType{
        none, //해당 없음이 디폴트 값. 해당 항복은 아이템 항목이 eqip일때만 설정합니다.
        weapon,
        top,
        pants,
        shoes
    }

    public enum ItemType
    {
        equip, //장비
        consumption, //소비
        normal, //일반
        quest, //퀘스트
        ETC //기타
    }

    public Item( int itemID, string itemName, string itemDescripton, Sprite itemIcon, ItemType itemType , EquipType equipType = EquipType.none)
    {
        this.itemID = itemID;
        this.itemName = itemName;
        this.itemDescripton = itemDescripton;
        this.itemIcon = itemIcon;
        this.itemType = itemType;
        this.equipType = equipType;
    }

    public void resetItemCount(){
        itemCount = 0;
    }

    public void IncreaseItemCount(int n){
        itemCount += n;
    }

    public int returnItemCount(){
        return itemCount;
    }

}
