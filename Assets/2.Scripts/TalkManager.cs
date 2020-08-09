using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        generateData();

    }



    // 대화할 문장 저장
    void generateData()
    {
        talkData.Add(1000, new string[] { "안녕", "나는 에드워드야" });

        talkData.Add(100, new string[] { "이건 돌이다!!!" });
    }


    public string GetTalk(int id, int talkindex)
    {
        if (talkindex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkindex];

    }

}
 