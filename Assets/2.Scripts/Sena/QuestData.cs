using System.Collections;
using System.Collections.Generic;


public class QuestData {

    public string Questname;
    public int[] npcId;
    

    // 생성자

    public QuestData(string name, int[] npc)
    {
        Questname = name;
        npcId = npc;
    }
}
