using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat instance;

    public int hp;
    public int currentHP;
    public int[] needExp;
    public int currentEXP;

    public int atk;
    public int def;
    
    public int characterLevel;

   
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
