using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    //QuestData 안에 string questName / int npdId 가 들어가 있음  

    public int questId; // 지금 진행중인 퀘스트의 번호
    public int questActionIndex; // 퀘스트 대화 순서 
    public GameObject[] questItem;



    //using Quest UI

    public GameObject QuestCanvas;
    public Text questname;
    bool a;



    Dictionary<int, QuestData> questlist;  // 퀘스트 내용을 저장


     void Start()
    {
        QuestCanvas.SetActive(false);
    }

    void Awake()
    {
        questlist = new Dictionary<int, QuestData>(); // 리스트 새로 선언
        GenerateData(); // 여기서 퀘스트 내용 만들거임 
        fuc();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // 만약 I 키가 눌리면
        {
            if (a == false)
            {
                QuestCanvas.SetActive(true);

                a = true;
                return;
            }
            else
            {
                QuestCanvas.SetActive(false);
                a = false;
                return;
            }

        }
    }



    // Update is called once per frame

    void GenerateData()
    {
        questlist.Add(10,new QuestData("슬라임 사냥하기!",new int[] { 1000,2000})); //퀘스트를 하나 새로 생성할건데, 퀘스트 번호는 10번임
        questlist.Add(20, new QuestData("슬라임 방울을 상점에 팔기", new int[] { 1000, 5000 })); //퀘스트를 하나 새로 생성할건데, 퀘스트 번호는 20번임

    }

    public int GetQuestTalkIndex(int id) { 


        return questId + questActionIndex;

        
    }
    public string CheckQuest(int id) // 대화진행 순서 id 는 npcid 
    {

        //controlItem();
        
        if(id ==questlist[questId].npcId[questActionIndex]) // 내가 지정한 npc와 대화를 하면
            questActionIndex++; // index가 올라간다
        controlItem();
        if (questActionIndex == questlist[questId].npcId.Length) // 처음 퀘스트가 끝마쳐지면
            NextQuest(); // 다음 퀘스트를 불러온다 

        return questlist[questId].Questname; //  

    }

    public void NextQuest()
    {
        questId += 10;
        questActionIndex = 0; // index 초기화 

    }


    public void controlItem()
    {
        switch(questId)
        {
            case 10:
                if(questActionIndex == 2)
                {
                    questItem[0].SetActive(true);

                }
                break;
            case 20:
                if (questActionIndex == 1)
                {
                    questItem[0].SetActive(false);

                }
                break;
        }
    }

     // 아래에서 퀘스트 이름 받아오기 수정 봐야댐
    public void fuc()
    {
        questname.text = questlist[10].Questname;
    }
}
