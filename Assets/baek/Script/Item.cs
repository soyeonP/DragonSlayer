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
    public int itemCount;
    public Sprite itemIcon;
    public ItemType itemType;

   //public string itemSpriteFileName; //아이템 스프라이트 파일 이름

    public enum ItemType
    {
        equip, //장비
        consumption, //소비
        normal, //일반
        quest, //퀘스트
        ETC //기타
    }

    public Item( int itemID, string itemName, string itemDescripton, int itemCount, Sprite itemIcon, ItemType itemType )
    {
        this.itemID = itemID;
        this.itemName = itemName;
        this.itemDescripton = itemDescripton;
        this.itemCount = itemCount;
        this.itemIcon = itemIcon;
        this.itemType = itemType;
    }


}
