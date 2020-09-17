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
    public GameObject Element1;
    public GameObject Element2;
    private Animator animator;
    private Transform EnemyTr;
    private Transform transform;
    private SceneMusicPlay musicPlay_hurt;

    GameObject myResponeObj;
    public int spawnID { get; set; }

    Vector3 originPos;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        currentHp = hp;
        animator = GetComponent<Animator>();
        musicPlay_hurt = new SceneMusicPlay(GameObject.Find("MonsterHurtSE"));
    }

    public void setRespawnObj(GameObject respawnObj, int spawnID, Vector3 originPos)
    {
        myResponeObj = respawnObj;
        this.spawnID = spawnID;
        this.originPos = originPos;
    }
    public int Hit(int _playerAtk)
    {
        musicPlay_hurt.MusicStart();
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
            Vector3 itemPosition = new Vector3(transform.position.x, (float)(Element1.GetComponent<Transform>().position.y+0.2), transform.position.z);
            Debug.Log(transform.position+" gg");
            Instantiate(Element1, itemPosition, transform.rotation);


            myResponeObj.GetComponent<MonsterManager>().RemoveMonster(spawnID);
            //Destroy(this.gameObject);

            PlayerStat.instance.currentEXP += exp;


        }

        return dmg;
    }

    
}
