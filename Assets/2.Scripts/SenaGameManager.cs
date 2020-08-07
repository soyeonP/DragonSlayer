using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SenaGameManager : MonoBehaviour
{

    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;

    public void Start()
    {
        isAction = false;
        talkPanel.SetActive(false);
    }


    public void Action(GameObject scanobj)
    {
        Debug.Log(isAction);
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            scanObject = scanobj;
            talkText.text = "이것의 이름은 " + scanObject.name + "이라고 한다.";
        }
        talkPanel.SetActive(isAction);

    }

}
