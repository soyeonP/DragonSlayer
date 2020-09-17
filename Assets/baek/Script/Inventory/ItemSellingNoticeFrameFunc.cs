using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSellingNoticeFrameFunc : MonoBehaviour
{
    static GameObject noticeFrame;
    public static Item item;
    public static int itemCount;

    void Start()
    {
        noticeFrame = GameObject.Find("NoticeFrame");
        noticeFrame.SetActive(false);
    }

    public static GameObject returnNoticeFrameGameObject(){
        return noticeFrame;
    }

    public void CloseNoticeFrame(){
        noticeFrame.SetActive(false);
    }

    public void SellItemInNoticeFrame(){
        if(item.returnItemCount() > itemCount){
            Inventory.instance.Add(item, itemCount * -1);
        }else{
            Inventory.instance.Remove(item);
        }
    }

}
