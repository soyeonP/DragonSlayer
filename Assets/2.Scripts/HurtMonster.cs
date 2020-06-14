using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtMonster : MonoBehaviour
{
    public string atkSound;

    private PlayerStat thePlayerStat;
    // Start is called before the first frame update
    void Start()
    {
        thePlayerStat = FindObjectOfType<PlayerStat>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            int dmg = collision.gameObject.GetComponent<MonsterStat>().Hit(thePlayerStat.atk);
            //attack sound 추가
        }

    }
}
