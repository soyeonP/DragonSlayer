using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class conversation : MonoBehaviour
{

    public GameObject all;
    public GameObject select;
    public Text npc_name;
    public Text dialog;
    public int textline; // 유니티 외부에서 적어주기 
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        select.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void OnClickQuest()
    {
        while (count != textline)
        {
            if (count == 0)
            {
                npc_name.text = "닉네임";
                dialog.text = "안녕, 에드워드";
                print(count); 
                count++;
                return;
            }

            else if(count == 1)
            {
                npc_name.text = "에드워드";
                dialog.text = "닉네임 이잖아, 일찍 일어났네. 잘 잤어?";
                print(count); 
                count++;
                return;
            }

            else if(count==2)
            {
                select.SetActive(true);
                print(count);
                count++;
                return;
                
            }
            else if(count==3)
            {
                npc_name.text = "에드워드";
                dialog.text = "건강 관리 잘해";
                print(count);
                count++;
                return;
            }

            else
            {
                all .SetActive(false);
                return;
            }

        }


    }

}
