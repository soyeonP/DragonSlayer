using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalManager : MonoBehaviour
{
    public GameObject SceneManager;
    public LoadScene loadSceneScript;
    // Start is called before the first frame update
    void Start()
    {
        loadSceneScript = SceneManager.GetComponent<LoadScene>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("enter the scene");
            loadSceneScript.ChangeScene();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
