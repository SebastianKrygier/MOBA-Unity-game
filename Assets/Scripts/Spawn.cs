using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    public GameObject[] SpawnBrown;
    public GameObject[] SpawnGrey;
    [SerializeField] private GameObject prefab = null;


    // Start is called before the first frame update
    void Start()
    {
        //GameObject player = PhotonNetwork.Instantiate("Robot Kyle", SpawnBrown[0].transform.position, SpawnBrown[0].transform.rotation,0);
        //player.GetComponent<PlayerMove>().enabled = true;
        //player.GetComponent<Animator>().enabled = true;

        PhotonNetwork.Instantiate(prefab.name, SpawnBrown[0].transform.position, SpawnBrown[0].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
}
