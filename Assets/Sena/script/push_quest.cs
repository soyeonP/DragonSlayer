using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push_quest : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject quest_log; // 양피지 등
    public GameObject my_button; // 버튼 



    void Start()
    {
        quest_log.SetActive(false); // 처음에는 안보이다가
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickQuest()
    {
        Debug.Log("퀘스트OR대화하기 버튼 눌림"); 
        quest_log.SetActive(true); // 버튼이 눌리면 보이게함
        my_button.SetActive(false);
    }

}
