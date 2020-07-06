using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyUI : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        string money = PlayerMoney.instance.returnMoney().ToString();
        this.gameObject.GetComponent<Text>().text = money + "$";
        
    }
}
