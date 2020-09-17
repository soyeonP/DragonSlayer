using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Shop/Item(for shop)")] //프로젝트-에셋 창에 아이템 파일을 생성할 수 있게 해줍니다.
public class ItemForShop : ScriptableObject //상속 - 스크립팅 가능한 오브젝트. 상세 설명 메뉴얼 참고.
{

    public Item item;
    [TextArea(3,5)] public string itemShopDescripton;

    public int price;

    public ItemForShop( Item item, string itemShopDescripton, int price)
    {
        this.item = item;
        this.itemShopDescripton = itemShopDescripton;
        this.price = price;
    }

}
