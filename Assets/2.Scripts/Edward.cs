using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edward : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject dialog; // 에드워드 대화창 할당할 것 
    void Start()
    {
        npc Edward = new npc();

        Edward.npcname = "에드워드";
        Edward.age = 21;
        Edward.love = 30;

    }

    // Update is called once per frame
    void Update() // 
    {

       
            if (Input.GetMouseButton(0)) // 에드워드가 클릭 되었을때
            {
                dialog.SetActive(true);// 대화 스크립트 뜨기 
            }

            if (Input.GetKeyDown(KeyCode.Escape)) // ESC 누르면
            {
                dialog.SetActive(false);// 대화 스크립트 끄기
            }
        
    }
}
