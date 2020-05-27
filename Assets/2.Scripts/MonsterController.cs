using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private Transform EnemyTr;
    private Transform PlayerTr;

    private GameObject player;
    private PlayerController playerScript;

    public enum EnemyState { idle, trace, attack, die, PlayerDie };
    public EnemyState enemyState = EnemyState.idle;
    public float attackDist = 2.0f;
    public float BornTime;


    void Start()
    {
        player = GameObject.FindWithTag("Player");

        EnemyTr = this.gameObject.GetComponent<Transform>();
        PlayerTr = player.GetComponent<Transform>();
        //nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        playerScript = player.GetComponent<PlayerController>();
    }
    //https://wikidocs.net/18505
    // Update is called once per frame
    void Update()
    {
        
    }
}
