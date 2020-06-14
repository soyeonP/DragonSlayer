using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    public float offsetX = 0f;
    public float offsetY = 10f;
    public float offsetZ = -9f;
    public float followSpeed = 10f;

    Vector3 cameraPosition;

    void Start()
    {
        Screen.SetResolution(1280, 720, false);
    }

    void LateUpdate()
    {
        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = player.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;

        //transform.position = cameraPosition;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, followSpeed * Time.deltaTime);

    }
}
