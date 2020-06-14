using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        musicPlay = new SceneMusicPlay(seManager);
        if (inventoryUI != null) inventoryUI.SetActive(false);
        if(seManager != null) musicPlay.GameObjectWithAudioSource = seManager;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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
            }
        }
    }

    public void CloseInventory()
    {
        musicPlay.MusicChange(inventoryOpenSE);
        musicPlay.MusicStart();
        inventoryUI.SetActive(false);
        isOpenInventory = false;
    } 
    
}
