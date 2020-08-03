using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interactable : MonoBehaviour
{
    public float radius = 0.8f;

    private Transform player;
    private bool hasInteracted = false;

    void OnDrawGizmosSelected()
    {
        //접촉 가능 반경 기즈모로 표시
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    public virtual void Interact()
    {
        //오버라이딩 가능
        //Debug.Log("접촉 " + transform.name);
    }

    private void Awake()
    {

        player =GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    void Update()
    {

        float distance = Vector3.Distance(player.position, transform.position);
        if (!hasInteracted)
        {
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
                if (this.gameObject != null) hasInteracted = false;
            }
        }
    }

}
