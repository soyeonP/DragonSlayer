using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : MonoBehaviour
{
    public int hp;
    public int currentHp;
    public int atk;
    public int def;
    public int exp;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = hp;
        animator = GetComponent<Animator>();
    }

    public int Hit(int _playerAtk)
    {
        animator.SetTrigger("attacked");
        int playerAtk = _playerAtk;
        int dmg;
        if (def >= playerAtk)
            dmg = 1;
        else
            dmg = playerAtk - def;

        currentHp -= dmg;

        if(currentHp <= 0)
        {
            Destroy(this.gameObject);
            PlayerStat.instance.currentEXP += exp;
        }

        return dmg;
    }


}
