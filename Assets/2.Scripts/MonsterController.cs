using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    private Transform EnemyTr;
    private Transform PlayerTr;
    private NavMeshAgent nvAgent;
    private GameObject player;
    private PlayerController playerScript;
    public List<Transform> wayPoints;
    private Animator animator;
    private float damege = 10.0f;

    public enum EnemyState { idle, trace, attack, die, move, playerDie };
    public EnemyState enemyState = EnemyState.idle;
    public float attackDist = 2.0f;
    public float BornTime;


    void Start()
    {
        player = GameObject.FindWithTag("Player");

        EnemyTr = this.gameObject.GetComponent<Transform>();
        PlayerTr = player.GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        playerScript = player.GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyState = EnemyState.idle;


    }

    void OnCollisionStay(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            Debug.Log("attacked");
            if(playerScript.isAttack){
                Debug.Log("몬스터 스크립트 내부 "+playerScript.isAttack);
                Debug.Log("attacked");
                animator.SetTrigger("attacked");
            }
           // Debug.Log("collisionEvent for monster");

           // Debug.Log("collisionEvent : monster attacked");
        }
    }
}
