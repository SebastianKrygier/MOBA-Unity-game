using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CameraMove : MonoBehaviourPun
{
    public float speed = 25;
    public float size = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if (Input.mousePosition.y >= Screen.height - size) // move up
        {
            position.z += speed * Time.deltaTime;
        }

        if (Input.mousePosition.y <= size) // move down
        {
            position.z -= speed * Time.deltaTime;
        }

        if (Input.mousePosition.x >= Screen.width - size) // move right
        {
            position.x += speed * Time.deltaTime;
        }

        if (Input.mousePosition.x <= size) // move left
        {
            position.x -= speed * Time.deltaTime;
        }

        transform.position = position;
    }
}