using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraMove : MonoBehaviour
{
    public float speed = 25;
    public float size = 10;
    public GameObject SpawnBrown;
    public GameObject SpawnGray;
    public Vector3 position;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.NickName == "1" || PhotonNetwork.NickName == "3" || PhotonNetwork.NickName == "5")
        {
            position = SpawnBrown.transform.position+offset;
        }
        else
        {
            position = SpawnGray.transform.position+offset;
        }
        //Camera.transform.position=player.transform.position+offset;

    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.z<650){
                if (Input.mousePosition.y >= Screen.height - size) // move up
                {
                    position.z += speed * Time.deltaTime;
                }
            }
             if(transform.position.z>35){
                if (Input.mousePosition.y <= size) // move down
                {
                    position.z -= speed * Time.deltaTime;
                }
             }
            if(transform.position.x<595){
                if (Input.mousePosition.x >= Screen.width - size) // move right
                {
                    position.x += speed * Time.deltaTime;
                }
            }
            if(transform.position.x>380){
                if (Input.mousePosition.x <= size) // move left
                {
                    position.x -= speed * Time.deltaTime;
                }
            }

            transform.position = position;
    }
}