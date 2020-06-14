using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sure : MonoBehaviour
{
    public GameObject all_dialog;
    public bool answer;

    // Start is called before the first frame update
    void Start()
    {
        answer = false;
        Debug.Log("answer false");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick() // 퀘스트 수락하기 클릭
    {
        answer = true;
        Debug.Log(answer);
        all_dialog.SetActive(false); 




        return;
    }
}
