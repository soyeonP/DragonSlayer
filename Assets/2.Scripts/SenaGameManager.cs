using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SenaGameManager : MonoBehaviour
{

    public TalkManager Talkmanager;
    public QuestManager questManager;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkindex;
    public GameObject humancanvas;

    //public GameObject talktohim;

    


    //using Quest UI

   //public GameObject QuestCanvas;
  //  public Text questname;
  //  bool a;




    public void Start()
    {
        isAction = false;
        talkPanel.SetActive(false);
      //  QuestCanvas.SetActive(false);
        humancanvas.SetActive(false);

    }

    // UI 뜨기 
    void Update()
    {
/*
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
*/
    }





    // 사물 스캔 인지
    public void Action(GameObject scanobj)
    {
 
            scanObject = scanobj;
            objData Objdata = scanObject.GetComponent<objData>();
            Talk(Objdata.id, Objdata.isNpc);
        
        talkPanel.SetActive(isAction);

    }




    // npc 대화부분

    void Talk(int id, bool isNpc)
    {

        int questTalkIndex = questManager.GetQuestTalkIndex(id);  // 여기에 id(npcid)와 매칭되는 퀘스트 아이디가 저장됌

        
        humancanvas.SetActive(true); // npc 캔버스 활성화

        
        string talkData = Talkmanager.GetTalk(id + questTalkIndex, talkindex);


        // End talk
        if (talkData == null)
        { 
            isAction = false;
            talkindex = 0;
            Debug.Log(questManager.CheckQuest(id)); // 대사가 끝나면 인덱스가 하나 올라감 
            humancanvas.SetActive(false);
            return;
        }

  

        if (isNpc)
        {
            talkText.text = talkData;

        }

        else
        {
            talkText.text = talkData;
            
        }
        isAction = true;
        talkindex++;
    }


}
