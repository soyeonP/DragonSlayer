using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{

    //인벤토리 여는데 관여
    public GameObject inventoryUI;
    bool isOpenInventory = false;

    //인벤토리 SE에 관여
    public GameObject seManager;
    SceneMusicPlay musicPlay;
    public AudioClip inventoryOpenSE;
    public AudioClip inventoryCloseSE;

    //상점 '아이템 판매' 상태 관여
    GameObject Tap_sell;
    GameObject Tap_buy;

    // Start is called before the first frame update
    void Start()
    {
        musicPlay = new SceneMusicPlay(seManager);
        if (inventoryUI != null) inventoryUI.SetActive(false);
        if(seManager != null) musicPlay.GameObjectWithAudioSource = seManager;
        Tap_sell = GameObject.Find("Tap_sell");
        Tap_buy = GameObject.Find("Tap_buy");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isOpenInventory)
            {
                if (musicPlay.GameObjectWithAudioSource != null)
                {
                    musicPlay.MusicChange(inventoryOpenSE);
                    musicPlay.MusicStart();
                    
                }
                inventoryUI.SetActive(true);
                isOpenInventory = true;
            }
            else
            {
                if (musicPlay.GameObjectWithAudioSource != null)
                {
                    musicPlay.MusicChange(inventoryCloseSE);
                    musicPlay.MusicStart();
                }
                inventoryUI.SetActive(false);
                isOpenInventory = false;

                //상점 탭 업데이트
                if(Tap_sell != null) Tap_sell.GetComponent<Toggle>().isOn = false;
                if(Tap_buy != null) Tap_buy.GetComponent<Toggle>().isOn = true;
            }
        }
    }

    public void OpenInventory_inShop(){
        //토글이 켜진 경우에만 인벤토리 엶
        if(GameObject.Find("Tap_sell").GetComponent<Toggle>().isOn){
            if (!isOpenInventory)
            {
                if (musicPlay.GameObjectWithAudioSource != null)
                {
                    musicPlay.MusicChange(inventoryOpenSE);
                    musicPlay.MusicStart();
                    
                }
                inventoryUI.SetActive(true);
                isOpenInventory = true;
            }             
        }
       
    }

    public void CloseInventory()
    {
        musicPlay.MusicChange(inventoryCloseSE);
        musicPlay.MusicStart();
        inventoryUI.SetActive(false);
        isOpenInventory = false;

        //상점 탭 업데이트
        if(Tap_sell != null) Tap_sell.GetComponent<Toggle>().isOn = false;
        if(Tap_buy != null) Tap_buy.GetComponent<Toggle>().isOn = true;
    } 
    
}
