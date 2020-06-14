using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject Element1;
    public GameObject Element2;
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Drop()
    {
        Instantiate(Element1, transform);
    }

}
