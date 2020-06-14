using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quest : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject empty;
    public Text mytext;
    // public GameObject sure;

    public bool haveQuest;

    void Start()
    {
        haveQuest = false;
    }

    // Update is called once per frame
    void Update()
    {
 
      /* if (answer==true) // a인 수락하기가 눌리면 
        {
            Debug.Log("undate in answer");
            return;
        }*/
    }

    public void OnClickQuest() // 퀘스트 버튼 눌릴시 
    {
        empty.SetActive(false);

       if(!haveQuest) // 퀘스트를 받기 전일 경우
        {
            mytext.text = "슬라임 방울을 모아와줄래?"; // 라는 글자가 나온다.
            haveQuest = true;
            Debug.Log("퀘스트 받는 중");
        }

        else // 퀘스트 받고 완료하기 코드 
        {
            mytext.text = "다 가져왔어?";
            /*if () // 인벤토리 내에 슬라임 방울이 있으면 
            {
                mytext.text = "고마워!";
                // 완료하기 버튼 보이기
                // 슬라임 방울 인벤토리에서 사라지게 하기
                return;
            }
            else
            {
                mytext.text = "아직 부족한 것 같은데?";

            }
            */
        }
        

        //mytext.text = "슬라임 방울을 모아와줄래?"; // 라는 글자가 나온다.

        //Debug.Log(answer);


    }

 

}
