using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    // Start is called before the first frame update
    public string npcname; // npc 이름
    public int age; // 나이
    public int love; // 호감도

    public GameObject dialog;


    void Start()
    {
        dialog.SetActive(false);  // dialog창 비활성화 

    }

    public void OnMouseDown() //npc인 에드워드가 눌리면
    {
        Debug.Log("에드워드 눌림"); 
        dialog.SetActive(true); // dialog창이 활성화댐
    
    }
}
