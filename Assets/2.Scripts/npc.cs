using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class npc : MonoBehaviour
{
    // Start is called before the first frame update

    public int love; // 호감도

    public GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("Canvas"); // Canvas 찾기
        canvas.gameObject.SetActive(false); // 기본적으로 보이지 않는 상태

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0)) // npc 클릭시가 아니라 그냥 클릭시임
        {
            //Debug.Log("클릭됨");
            canvas.gameObject.SetActive(true); //canvas가 보여짐 

        };
    }



}
