using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Stats : MonoBehaviourPunCallbacks, IDemagable
{
    public GameObject champion;
    public GameObject RespawnController;
    RespawnController respawnController;
    public PhotonView pv;

    public int level = 1;
    public int Gold = 0;
    public int Mana = 100;
    public int Xp = 0;
    public int giveXp;
    public int giveGold;

    public float maxHealth;
    public float health;
    public float attackDamage;
    public float attackSpeed;
    public float attackTime;
    public bool isHeroAlive=true;
    public string Team;
    private int temp; 

    private HeroCombat heroCombatScript;

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        temp=(int) info.photonView.InstantiationData[0];
        if(temp==0)
        {
            Team="Brown";
        }
        else if( temp == 1)
        {
            Team="Gray";
        }
        Debug.Log("Team:"+Team);
        //RespawnController.Find("RespawnController(Clone)");
        respawnController=RespawnController.GetComponent<RespawnController>();
    }
    


    // Update is called once per frame
    /*void FixedUpdate()
    {
        if (Xp >= 100)
        {
            int restOfXp = Xp - 100;
            Xp = restOfXp;

            respawnController.level++;
            respawnController.attackDamage += 10;
            respawnController.attackSpeed = (attackSpeed * 9 / 10);
            respawnController.Mana = 100;
        }
        health+=(respawnController.maxHealth-maxHealth);
        maxHealth=respawnController.maxHealth;
        attackDamage=respawnController.attackDamage;
        attackSpeed=respawnController.attackSpeed;
        level=respawnController.level;
        Gold=respawnController.Gold;
        Xp=respawnController.Xp;
    }*/

    

    public void TakeDemage(float Demage)
    {
        
        pv.RPC("RPC_TakeDemage", RpcTarget.All, Demage);
        //Debug.Log("Hero attack take dmg sent");
    }

    

    [PunRPC]
    void RPC_TakeDemage(float Demage)
    {
        if(!pv.IsMine)
        {
            return;
        }
        //Debug.Log("MinionTakingDmg");
        health -= Demage;
        if (health <= 0)
        {
            if(pv.IsMine)
            {
                Debug.Log("Player is dead.");
                RespawnController.GetComponent<IRespawn>()?.Respawn();
                //isHeroAlive=false;
                //heroCombatScript.targetedEnemy = null;
                //heroCombatScript.performMeleeAttack = false;
                PhotonNetwork.Destroy(champion);
            }
            
        }
    }

  
}