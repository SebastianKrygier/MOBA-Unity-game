using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    int PlayersNumber=PhotonNetwork.PlayerList.Length;
    public GameObject SpawnBrown;
    public GameObject SpawnGrey;
    public GameObject player=null;

    public GameObject Camera;

    public Vector3 offset;
    
    [SerializeField] private GameObject prefab;
    
    public float speed = 25;
    public float size = 10;


    // Start is called before the first frame update
    void Start()
    {
        
        //GameObject player = PhotonNetwork.Instantiate("Robot Kyle", SpawnBrown[0].transform.position, SpawnBrown[0].transform.rotation,0);
        //player.GetComponent<PlayerMove>().enabled = true;
        //player.GetComponent<Animator>().enabled = true;
        if (PhotonNetwork.NickName == "1")
        {
            player = PhotonNetwork.Instantiate(prefab.name, SpawnBrown.transform.position, SpawnBrown.transform.rotation);
        }
        else
        {
            player = PhotonNetwork.Instantiate(prefab.name, SpawnGrey.transform.position, SpawnGrey.transform.rotation);
        }
        player.GetComponent<PlayerMove>().enabled = true;
        Camera.transform.position=player.transform.position+offset;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player != null && Camera != null)
        {
            Vector3 position = Camera.transform.position;

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

        Camera.transform.position = position;
        }

    }
    void Update()
    { 
        
    }
}
