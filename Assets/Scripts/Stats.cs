using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Stats : MonoBehaviourPunCallbacks, IDemagable, IPunObservable
{
    public GameObject champion;
    public GameObject RespawnController;
    public RespawnController respawnController;
    public PhotonView pv;
    public GameObject attacker;

    public int level = 1;
    public int Gold = 0;
    public int Mana = 100;
    public int Xp = 0;
	public int XpForLvl=100;
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
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Xp);
			stream.SendNext(Gold);
			stream.SendNext(Mana);
			stream.SendNext(health);
        }
        else
        {
            Xp = (int)stream.ReceiveNext();
			Gold = (int)stream.ReceiveNext();
			Mana = (int)stream.ReceiveNext();
			health = (float)stream.ReceiveNext();
        }
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

    

    public void TakeDemage(float Demage, int pvId)
    {
        
        pv.RPC("RPC_TakeDemage", RpcTarget.All, Demage, pvId);
		attacker=PhotonView.Find(pvId).gameObject;
        //Debug.Log("Hero attack take dmg sent");
    }

    public void GetGoldAndXp(int GetXp, int GetGold){
		pv.RPC("RPC_GetGoldAndXp", RpcTarget.All, GetXp, GetGold);
	}

    [PunRPC]
    void RPC_GetGoldAndXp(int GetXp, int GetGold){
 	if(!pv.IsMine)
        {
            return;
        }
	respawnController.GetGoldAndXp(GetXp,GetGold);
    }

    [PunRPC]
    void RPC_TakeDemage(float Demage, int pvId)
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
				attacker=PhotonView.Find(pvId).gameObject;

                Debug.Log("Player is dead.");
                RespawnController.GetComponent<RespawnController>().Respawn();
                //isHeroAlive=false;
				if(attacker!=null){
					attacker.GetComponent<IDemagable>().GetGoldAndXp(giveXp, giveGold);
				}
                //heroCombatScript.targetedEnemy = null;
                //heroCombatScript.performMeleeAttack = false;
                PhotonNetwork.Destroy(champion);
            }
            
        }
    }

  
}