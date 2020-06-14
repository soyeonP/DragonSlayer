using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour
{

    public GameObject select_one;
   // public GameObject npc; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickQuest() // 퀘스트 버튼 눌릴시 
    {
        select_one.SetActive(false);
    }
}
