using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    int PlayersNumber;
    public GameObject[] SpawnBrown;
    public GameObject[] SpawnGrey;
    [SerializeField] private GameObject prefab = null;


    // Start is called before the first frame update
    void Start()
    {
        //GameObject player = PhotonNetwork.Instantiate("Robot Kyle", SpawnBrown[0].transform.position, SpawnBrown[0].transform.rotation,0);
        //player.GetComponent<PlayerMove>().enabled = true;
        //player.GetComponent<Animator>().enabled = true;
        if (PlayersNumber % 2 == 0)
        {
            PhotonNetwork.Instantiate(prefab.name, SpawnBrown[PlayersNumber].transform.position, SpawnBrown[PlayersNumber].transform.rotation);
        }
        else
        {
            PhotonNetwork.Instantiate(prefab.name, SpawnGrey[PlayersNumber].transform.position, SpawnGrey[PlayersNumber].transform.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
}
