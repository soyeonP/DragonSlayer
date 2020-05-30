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

        StartCoroutine(this.CheckEnemyState());
        StartCoroutine(this.EnemyAction());
    }

    IEnumerator CheckEnemyState()
    {
        while(enemyState != EnemyState.die && enemyState != EnemyState.playerDie)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(PlayerTr.position, EnemyTr.position);



            if(enemyState != EnemyState.idle)
            {
                if (playerScript.PlayerHP == 0)
                {
                    enemyState = EnemyState.playerDie;
                } else if (dist <= attackDist)
                {
                    enemyState = EnemyState.attack;
                    animator.SetBool("battle", true);
                }
                else
                {
                    enemyState = EnemyState.trace;
                }
            }
        }

        yield return null;
    }

    IEnumerator EnemyAction()
    {
        while (enemyState != EnemyState.playerDie)
        {

            switch (enemyState)
            {

                case EnemyState.trace:
                    nvAgent.SetDestination(PlayerTr.position);
                    break;

                case EnemyState.attack:
                    nvAgent.ResetPath();
                    animator.SetTrigger("attack");
                    playerScript.hurt(damege);
                    break;

                case EnemyState.die:
                    nvAgent.ResetPath();
                    this.gameObject.SetActive(false);
                    break;
            }

            yield return null;

        }

        void OnCollisionEnter(Collision coll)
        {
            if (coll.collider.tag == "weapon")
            {

                Debug.Log("Enemy Hit!");
                //몬스터 공격받는 애니메이션\
                animator.ResetTrigger("attacked");
                if (enemyState != EnemyState.idle)
                {
                    //StopAllCoroutines();
                    //enemyState = EnemyState.die;
                    StartCoroutine(EnemyAction());
                }

            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
 
        if (other.collider.tag == "Player")
        {
            Debug.Log("collisionEvent for monster");
            animator.SetTrigger("attacked");
            Debug.Log("collisionEvent : monster attacked");
        }
    }
}
