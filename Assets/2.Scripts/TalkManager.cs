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
        // 기본적으로 사물이 가지고있는 상호작용 대사 적기
        talkData.Add(1000, new string[] { "안녕", "나는 에드워드야" });
        talkData.Add(100, new string[] { "이건 돌이다!!!" });
        talkData.Add(700, new string[] { "여행객들이 많이 찾는 숙소다." });
        talkData.Add(800, new string[] { "마을의 주민 회관이다. " });




        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "안녕 난 에드워드야", 
                                                "갑자기 뜬금 없지만 옆의 헨리에게 3시에 이곳으로 와달라 해줄래?",
                                                "꼭 부탁해" });

        talkData.Add(11 + 2000, new string[] { "뭐?",
                                                "에드워드가 음... 알겠어.",
                                                "그럼 저기 있는 내 검 좀 가져다 주면 안돼? 시간이 없어서. 부탁할게" });

        talkData.Add(20 + 1000, new string[] { "내 말 전했어?" });
        talkData.Add(20 + 2000, new string[] { "이제 갈거야." });
        talkData.Add(20 + 5000, new string[] { "헨리의 검이다. 가지고 가자." });

        talkData.Add(21 + 1000, new string[] { "헨리는 방금 여기에 왔어",
                                                "검 가져다주러 온거야? 수고하네"});


    }


    public string GetTalk(int id, int talkindex)
    {
        if (!talkData.ContainsKey(id)) {
            


            if (!talkData.ContainsKey(id - id % 10))
            {
                return GetTalk(id - id % 100, talkindex);

            }
            else
                return GetTalk(id - id % 10, talkindex);

            // 퀘스트를 하는 도중 해당하는 id와 대화할 사항이 없을 때
            // 퀘스트 맨 처음 대사를 가지고 온다 

        } 

        if (talkindex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkindex];

    }

}
 