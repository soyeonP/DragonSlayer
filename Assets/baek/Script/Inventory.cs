using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public Text noticeText;

    //싱글톤 패턴 : 단 하나의 인스턴스를 생성해 사용하는 디자인 패턴
    #region Sigleton
    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("인벤토리 1개 이상 발견됨");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged(); //delegate: 함수에 대한 참조
    public OnItemChanged onItemChagedCallback;


    public List<Item> itemList = new List<Item>();
    int storage = 28; //최대 아이템 저장 갯수 28개

    public bool Add (Item item) //아이템 추가 성공여부 반환
    {
        //이미 인벤토리에 있는 아이테인지 확인. 이미 있었다면 수만 증감
        bool hasSameIDItem = false;
        int sameIDNum = 0;
        for (int i = 0; i<itemList.Count; i++){
            if(itemList[i].itemID == item.itemID) {hasSameIDItem = true; sameIDNum = i;}
        }

        if (itemList.Count >= storage)
        {
            noticeText.text = "인벤토리 공간이 부족합니다.";
            Debug.Log("텍스트 소환");
            StartCoroutine(FadeInOut()); //페이드 인아웃 코루틴
            return false;
        }
        
        if (!hasSameIDItem) itemList.Add(item);
        else itemList[sameIDNum].itemCount += item.itemCount;
        
        if (onItemChagedCallback != null)
            onItemChagedCallback.Invoke();

        return true;
    }
    public void Remove (Item item)
    {
        itemList.Remove(item);
        if (onItemChagedCallback != null)
            onItemChagedCallback.Invoke();
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
