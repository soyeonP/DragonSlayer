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
}
