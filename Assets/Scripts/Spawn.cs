using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    int PlayersNumber=PhotonNetwork.PlayerList.Length;
    public GameObject SpawnBrown;
    public GameObject SpawnGrey;
    
    [SerializeField] private GameObject prefab = null;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player;
        //GameObject player = PhotonNetwork.Instantiate("Robot Kyle", SpawnBrown[0].transform.position, SpawnBrown[0].transform.rotation,0);
        //player.GetComponent<PlayerMove>().enabled = true;
        //player.GetComponent<Animator>().enabled = true;
        if (PhotonNetwork.NickName == "1")
        {
            player =PhotonNetwork.Instantiate(prefab.name, SpawnBrown.transform.position, SpawnBrown.transform.rotation);
        }
        else
        {
            player =PhotonNetwork.Instantiate(prefab.name, SpawnGrey.transform.position, SpawnGrey.transform.rotation);
        }
        player.GetComponent<PlayerMove>().enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
}
