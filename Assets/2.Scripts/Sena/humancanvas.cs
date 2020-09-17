using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class humancanvas : MonoBehaviour
{
    // Start is called before the first frame update


    public int humanId=1000;

    public GameObject EdwardId;
    public GameObject ClaudeId;


    void Start()
    {
        EdwardId.SetActive(false);
        ClaudeId.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    switch (humanId)
        {
            case 1000:
                EdwardId.SetActive(true);
                break;
            case 2000:
                ClaudeId.SetActive(true);
                break;

        }


    }
}
