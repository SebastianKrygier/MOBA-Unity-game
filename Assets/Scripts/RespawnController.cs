using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RespawnController : MonoBehaviour, IRespawn
{
    int PlayersNumber = PhotonNetwork.PlayerList.Length;
    public GameObject SpawnBrown;
    public GameObject SpawnGray;
    public GameObject player = null;
    public GameObject Camera;

    public Vector3 offset;
    bool readyToStart = false;

    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;

    private float RespawnDelay;
    [SerializeField] private float InitialRespawnDelay;


    [SerializeField] private Spawn spawn;

    //player stasts
    public int level = 1;
    public int Gold = 0;
    public int Mana = 100;
    public int Xp = 0;
    public float maxHealth = 100;
    public float attackDamage = 10;
    public float attackSpeed = 1;
    private Stats statsScript;

    /*public void OnInstantiate()

    {
        spawn nie jest przypisany
        statsScript = spawn.player.GetComponent<Stats>();
    }
    */

    public void Respawn()
    {
        /*Debug.Log("Respawn Starts");
        RespawnDelay=InitialRespawnDelay;
        while(readyToStart)
        {
            RespawnDelay-= Time.deltaTime;
            if(RespawnDelay<0)
            {
                readyToStart=true;
            }
        }*/

        //InitialRespawnDelay+=10;
        Debug.Log(PhotonNetwork.NickName + "Players Nick");

        if (PhotonNetwork.NickName == "1")
        {
            player = PhotonNetwork.Instantiate(prefab1.name, SpawnBrown.transform.position,
                SpawnBrown.transform.rotation, 0);
        }
        else if (PhotonNetwork.NickName == "2")
        {
            player = PhotonNetwork.Instantiate(prefab2.name, SpawnGray.transform.position, SpawnGray.transform.rotation,
                0);
        }
        else if (PhotonNetwork.NickName == "3")
        {
            player = PhotonNetwork.Instantiate(prefab1.name, SpawnBrown.transform.position,
                SpawnBrown.transform.rotation, 0);
        }
        else if (PhotonNetwork.NickName == "4")
        {
            player = PhotonNetwork.Instantiate(prefab2.name, SpawnGray.transform.position, SpawnGray.transform.rotation,
                0);
        }
        else if (PhotonNetwork.NickName == "5")
        {
            player = PhotonNetwork.Instantiate(prefab1.name, SpawnBrown.transform.position,
                SpawnBrown.transform.rotation, 0);
        }
        else if (PhotonNetwork.NickName == "6")
        {
            player = PhotonNetwork.Instantiate(prefab2.name, SpawnGray.transform.position, SpawnGray.transform.rotation,
                0);
        }

        player.GetComponent<PlayerMove>().enabled = true;
        Debug.Log("Respawn Done");

        Camera.transform.position = player.transform.position + offset;
        readyToStart = false;

        //spawn.player = player;

       // statsScript = spawn.player.GetComponent<Stats>();
    }

    /*public void Update()
    {
        //statsScript.maxHealth = maxHealth;
        //statsScript.attackDamage = attackDamage;
        //statsScript.attackSpeed = attackSpeed;
        //statsScript.level = level;
        //statsScript.Xp = Xp;
        //statsScript.Gold = Gold;
    }*/
}