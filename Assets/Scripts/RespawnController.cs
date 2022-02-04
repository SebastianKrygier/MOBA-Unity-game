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
    

    [SerializeField]
    public PhotonView pv;
     

    public Vector3 offset;
    bool readyToStart = false;

    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;

    private float RespawnDelay;
    [SerializeField] private float InitialRespawnDelay ;
    private string playername;

    [SerializeField] private Spawn spawn;

    //player stasts
    public int level = 1;
    public int Gold = 10000;
    public int Mana = 100;
    public int Xp = 0;
    public float maxHealth = 3000;
    public float attackDamage = 90;
    public float attackSpeed = 1;
    private Stats statsScript;

    /*public void OnInstantiate()

    {
        spawn nie jest przypisany
        statsScript = spawn.player.GetComponent<Stats>();
    }
    */
    public void AddMaxHealth()
    {
        if(Gold>100)
        {
            maxHealth=maxHealth+20;
            Gold=Gold-100;
            Debug.Log("Buying more helph using gold");
            Debug.Log("Gold after transaction" + Gold);
        }
    }
    public void AddAttackDemage()
    {
        if(Gold>100)
        {
            attackDamage=attackDamage+10;
            Gold=Gold-100;
            Debug.Log("Buying more attack demage using gold");
            Debug.Log("Gold after transaction" + Gold);
        }
    }

    


    public void AddAttackSpeed()
    {
        if(Gold>100)
        {
            attackSpeed=(attackSpeed * 9 / 10);
            Gold=Gold-100;
            Debug.Log("Buying more attack speed gold");
            Debug.Log("Gold after transaction" + Gold);
        }
    }

    public void Respawn()
    {
	player=null;
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
        Debug.Log(PhotonNetwork.NickName + "Player is beeing respawned");
        

        if (PhotonNetwork.NickName == "1")
        {
            playername = prefab1.name;
            player = (PhotonNetwork.Instantiate(prefab1.name, SpawnBrown.transform.position,
                SpawnBrown.transform.rotation, 0) as GameObject);
        }
        else if (PhotonNetwork.NickName == "2")
        {
	    playername = prefab2.name;
            player = (PhotonNetwork.Instantiate(prefab2.name, SpawnGray.transform.position, SpawnGray.transform.rotation,
                0) as GameObject);
        }
        else if (PhotonNetwork.NickName == "3")
        {
            playername = prefab1.name;
            player = (PhotonNetwork.Instantiate(prefab1.name, SpawnBrown.transform.position,
                SpawnBrown.transform.rotation, 0) as GameObject);
        }
        else if (PhotonNetwork.NickName == "4")
        {
	    playername = prefab2.name;
            player = (PhotonNetwork.Instantiate(prefab2.name, SpawnGray.transform.position, SpawnGray.transform.rotation,
                0) as GameObject);
        }
        else if (PhotonNetwork.NickName == "5")
        {
	    playername = prefab1.name;
            player = (PhotonNetwork.Instantiate(prefab1.name, SpawnBrown.transform.position,
                SpawnBrown.transform.rotation, 0) as GameObject);
        }
        else if (PhotonNetwork.NickName == "6")
        {
	    playername = prefab2.name;
            player = (PhotonNetwork.Instantiate(prefab2.name, SpawnGray.transform.position, SpawnGray.transform.rotation,
                0) as GameObject);
        }
        if(pv.IsMine)
        {
            player.GetComponent<PlayerMove>().enabled = true;
        }
        Debug.Log("Respawn Done");

        Camera.transform.position = player.transform.position + offset;
        readyToStart = false;

        //spawn.player = player;

	

       statsScript = player.GetComponent<Stats>();
       
    }
    

    public void Update()
    {
	if(player == null){
		player=GameObject.Find(playername + "(Clone)");
	}
        if(player!=null)
        {
	    if(player.GetComponent<Stats>().maxHealth!=maxHealth){
		float diff = player.GetComponent<Stats>().maxHealth-maxHealth;
	    	player.GetComponent<Stats>().maxHealth = maxHealth;
		player.GetComponent<Stats>().health=player.GetComponent<Stats>().health-diff;
	    }
            player.GetComponent<Stats>().respawnController=this;
            player.GetComponent<Stats>().attackDamage = attackDamage;
            player.GetComponent<Stats>().attackSpeed = attackSpeed;
            player.GetComponent<Stats>().level = level;
            player.GetComponent<Stats>().Xp = Xp;
            player.GetComponent<Stats>().Gold = Gold;
        }
    }

    public void GetGoldAndXp(int GetXp, int GetGold){
	Xp=Xp+GetXp;
	Gold=Gold+GetGold;
    }
}