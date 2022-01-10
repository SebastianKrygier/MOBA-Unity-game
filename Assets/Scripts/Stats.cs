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
        
    }

    

    public void TakeDemage(float Demage)
    {
        
        pv.RPC("RPC_TakeDemage", RpcTarget.All, Demage);
    }

    

    [PunRPC]
    void RPC_TakeDemage(float Demage)
    {
        if(!pv.IsMine)
        {
            return;
        }
        Debug.Log("MinionTakingDmg");
        health -= Demage;
        if (health <= 0)
        {
            if(pv.IsMine)
            {
                RespawnController.GetComponent<IRespawn>()?.Respawn();
                isHeroAlive=false;
                //heroCombatScript.targetedEnemy = null;
                //heroCombatScript.performMeleeAttack = false;
                PhotonNetwork.Destroy(champion);
            }
            
        }
    }

  
}