using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Transform tr;
    private Vector3 movement;
    private Rigidbody rigidbody;
    private Animator animator;
    public GameObject attackBoundary;

    public float moveSpeed ;
    public float rotSpeed = 80.0f;
    public float PlayerHP = 100.0f;

    private float h;
    private float v;
    private float r;

    private float level;
    private float hp;
    private float power;
    private float defense;
    public bool isAttack;
    public bool notMove;
    public bool canMove = true;
    public float attakDelay;
    private float currentAttackDelay;
    private SceneMusicPlay musicPlay_walk;
    private SceneMusicPlay musicPlay_sword;
    private SceneMusicPlay musicPlay_attack;



    void Start()
    {
        tr = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isAttack = false;
        notMove = false;
        musicPlay_walk = new SceneMusicPlay(GameObject.Find("Walk"));
        musicPlay_sword = new SceneMusicPlay(GameObject.Find("SwordSE"));
        musicPlay_attack = new SceneMusicPlay(GameObject.Find("AttackSE"));
    }

    IEnumerator MoveCoroutine()
    {

        while ((h != 0 || v != 0) && !notMove && !isAttack)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            move(h, v);
            turn();
          
            animationUpdate();

            yield return new WaitForSeconds(0.01f);
        }

        musicPlay_walk.MusicStop();
        canMove = true;
    }

    bool check(float h, float v)
    {
        if (Math.Round(h, 1) == 0 && Math.Round(v, 1) == 0)
            return true;
        else
            return false;
        
    }

    // Update is called once per frame
    void Update()   
    {
        
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        
        if(canMove && !isAttack && !notMove)
        {
            if(h!=0 || v != 0)
            {
                musicPlay_walk.MusicStart();
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }
        }

        if(!notMove && !isAttack)
        {
            if (Input.GetButtonDown("Fire1")&& !EventSystem.current.IsPointerOverGameObject())
            {
                musicPlay_attack.MusicStart();
                musicPlay_sword.MusicStart();
                currentAttackDelay = attakDelay;
                attack();
                Debug.Log("attack!");
            }
        }

        if (isAttack)
        {
            attackBoundary.SetActive(true);
            currentAttackDelay -= Time.deltaTime;
            if(currentAttackDelay <= 0)
            {
                isAttack = false;
                attackBoundary.SetActive(false);
            }
        }

        
    }

    private void move(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        rigidbody.MovePosition(tr.position + movement);

    }

    private void turn()
    {
        if (h == 0 && v == 0)
            return;

        Quaternion newRotation = Quaternion.LookRotation(movement);

        rigidbody.MoveRotation(newRotation);
    }

    public float attack()
    {
        isAttack = true;
        animator.SetTrigger("attack");
        // power 와 몬스터 상태를 계산해 공력력을 내보낸다
        //isAttack=false;
        
        return power;
    }

    public void hurt(float damage)
    {
        //받은 데미지 만큼 hp 감소
        hp = -damage;
    }
    private void animationUpdate()
    {
        if (check(h,v))
            animator.SetBool("isRunning", false);
        else
            animator.SetBool("isRunning", true);
    }

    void OnCollisionExit(Collision other)
    {

    }
    void OnCollisionStay(Collision other){
        if (other.collider.tag == "Monster" )
        {
            Debug.Log("collisionEvent : can attack monster");
        }
    }
}
