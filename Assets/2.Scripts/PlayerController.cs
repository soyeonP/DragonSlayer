using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform tr;
    private float h;
    private float v;
    
    private float level;
    private float hp;
    private float power;
    private float defense;
    public float moveSpeed = 10.0f;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        move(h, v);
        
    }

    private void move(float h, float v)
    {
        //이동 인풋을 받아 캐릭터를 속도만큼 이동시킴 
        h = h * moveSpeed * Time.deltaTime;
        v = v * moveSpeed * Time.deltaTime;
        tr.Translate(Vector3.right * h);
        tr.Translate(Vector3.forward * v);
    }

    private float attack()
    {
        // power 와 몬스터 상태를 계산해 공력력을 내보낸다
        return power;
    }

    private void hurt(float damage)
    {
        //받은 데미지 만큼 hp 감소
        hp = -damage;
    }

}
