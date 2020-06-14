using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Start()
    {

    }
    // Start is called before the first frame update
    public void OnClickExit()
    {
        Debug.Log("quit!!!");
        Application.Quit();


    }
}
