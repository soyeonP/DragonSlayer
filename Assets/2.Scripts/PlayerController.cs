using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform tr;
    private Vector3 movement;
    private Rigidbody rigidbody;
    private Animator animator;
    private float h;
    private float v;
    private float r;
    
    private float level;
    private float hp;
    private float power;
    private float defense;
    public float moveSpeed = 10.0f;
    public float rotSpeed = 80.0f;
    public float PlayerHP = 100.0f;

    void Start()
    {
        tr = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        move(h, v);
        turn();
        if (Input.GetButtonDown("Fire1")){
            attack();
        }
        animationUpdate();
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
        animator.SetTrigger("attack");
        // power 와 몬스터 상태를 계산해 공력력을 내보낸다
        return power;
    }

    public void hurt(float damage)
    {
        //받은 데미지 만큼 hp 감소
        hp = -damage;
    }
    private void animationUpdate()
    {
        if (h == 0 && v == 0)
            animator.SetBool("isRunning", false);
        else
            animator.SetBool("isRunning", true);
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("collisionEvent");
        if (other.collider.tag == "Monster" )
        {
            animator.SetTrigger("attack");
            Debug.Log("collisionEvent : monster attack");
        }
    }
}
