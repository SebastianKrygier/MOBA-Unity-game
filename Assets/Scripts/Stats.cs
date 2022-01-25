using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Stats : MonoBehaviourPunCallbacks, IDemagable
{
    public GameObject champion;
    public GameObject RespawnController;

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
    }
    


    // Update is called once per frame
    void Update()
    {
        if (Xp >= 100)
        {
            int restOfXp = Xp - 100;
            Xp = restOfXp;

            RespawnController.GetComponent<RespawnController>().level++;
            RespawnController.GetComponent<RespawnController>().attackDamage += 10;
            RespawnController.GetComponent<RespawnController>().attackSpeed = (attackSpeed * 9 / 10);
            RespawnController.GetComponent<RespawnController>().Mana = 100;
        }
        maxHealth=RespawnController.GetComponent<RespawnController>().maxHealth;
        attackDamage=RespawnController.GetComponent<RespawnController>().attackDamage;
        attackSpeed=RespawnController.GetComponent<RespawnController>().attackSpeed;
        level=RespawnController.GetComponent<RespawnController>().level;
        Gold=RespawnController.GetComponent<RespawnController>().Gold;
        Xp=RespawnController.GetComponent<RespawnController>().Xp;
    }

    

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