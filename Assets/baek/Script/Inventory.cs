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

    public bool IsSameItemExist(Item i){
        if(itemList.Exists(x => x.itemID == i.itemID)) return true;
        return false;
    }

    // public void IncreaseItemCount(Item i){
    //     if(IsSameItemExist(i)){ //아이템이 있을 경우
    //         itemList.Find(x => x.itemID == i.itemID).itemCount += i.itemCount; //받아온 아이템 갯수만큼 갯수 증감
    //         Debug.Log(itemList.Find(x => x.itemID == i.itemID).itemCount);
    //     }else{
    //         Debug.Log("Inventory Script : 아이템 없는 상태에서 IncreaseItemCount 함수 사용. 아이템을 추가하십시오.");
    //     }
    // }
    //  public void IncreaseItemCount(Item i, int n){
    //     if(IsSameItemExist(i)){ //아이템이 있을 경우
    //         itemList.Find(x => x.itemID == i.itemID).itemCount += n; //함수에 입력된 임의의 수만큼 갯수 증감
    //     }else{
    //         Debug.Log("Inventory Script : 아이템 없는 상태에서 IncreaseItemCount 함수 사용. 아이템을 추가하십시오.");
    //     }
    // }   

    public bool Add (Item item, int count) //아이템 추가 성공여부 반환
    {
        //이미 인벤토리에 있는 아이템인지 확인. 이미 있었다면 수만 증감
        if(IsSameItemExist(item)){
            itemList.Find(x => x.itemID == item.itemID).IncreaseItemCount(count);
            return true;
        }
        else{
            if (itemList.Count >= storage)
            {
                noticeText.text = "인벤토리 공간이 부족합니다.";
                Debug.Log("텍스트 소환");
                StartCoroutine(FadeInOut()); //페이드 인아웃 코루틴
                return false;
            }
            item.resetItemCount(); //처음 인벤토리에 들어오는 아이템이라면 0으로 갯수를 초기화 한 뒤, 갯수만큼 넣기
            item.IncreaseItemCount(count); 
            itemList.Add(item);
        }
        
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
