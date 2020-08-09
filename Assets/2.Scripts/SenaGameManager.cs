using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SenaGameManager : MonoBehaviour
{

    public TalkManager Talkmanager;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkindex;



    public void Start()
    {
        isAction = false;
        talkPanel.SetActive(false);
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
        string talkData = Talkmanager.GetTalk(id, talkindex);

        if (talkData == null)
        {
            isAction = false;
            talkindex = 0;
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
