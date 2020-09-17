using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyShopItem : MonoBehaviour
{

    private GameObject shopItem;
    private ItemForShop itemForShop;

    Text noticeText;

    void Start(){
        shopItem = this.gameObject;
        itemForShop = shopItem.GetComponent<SettingShopItems>().itemForShop;
        noticeText = GameObject.Find("NoticeText").GetComponent<Text>();
    }

    public void buyItem(){
        if(PlayerMoney.instance.returnMoney() < itemForShop.price){
                noticeText.text = "금액이 부족합니다.";
                StartCoroutine(FadeInOut()); //페이드 인아웃 코루틴
        }else{
            PlayerMoney.instance.reduceMoney(itemForShop.price);
            Inventory.instance.Add(itemForShop.item, 1);
            noticeText.text = itemForShop.item.itemName + "을 구입하였습니다.";
            StartCoroutine(FadeInOut()); //페이드 인아웃 코루틴
        }
    }


IEnumerator FadeInOut()
    {
        Color textColor = noticeText.color;

        bool thisTexting = false;
        if (!thisTexting) //공지 텍스트가 나오고 있는도중엔 재실행 X
        {
            thisTexting = true;
            while (textColor.a <= 1f)
            {
                textColor.a += 0.1f;
                noticeText.color = textColor;
                yield return new WaitForSeconds(0.03f);
            }
            yield return new WaitForSeconds(1.5f);
            while (textColor.a >= 0f)
            {
                textColor.a -= 0.1f;
                noticeText.color = textColor;
                yield return new WaitForSeconds(0.03f);
            }
            thisTexting = false;
        }

        

    }

}
