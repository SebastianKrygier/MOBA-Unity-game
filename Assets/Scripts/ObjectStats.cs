using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ObjectStats : MonoBehaviourPunCallbacks, IDemagable
{
    public GameObject champion;
    //public GameObject RespawnController;

    public PhotonView pv;
    public GameObject attacker;

    

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

            level++;
            attackDamage += 10;
            attackSpeed = (attackSpeed * 9 / 10);
            Mana = 100;
        }
    }

    

    public void TakeDemage(float Demage, int pvId)
    {
        
        pv.RPC("RPC_TakeDemage", RpcTarget.All, Demage, pvId);
        attacker=PhotonView.Find(pvId).gameObject;
        //attacker=attarckerPv.gameObject;
    }

    public void GetGoldAndXp(int GetXp, int GetGold){
	return;
    }

    


    [PunRPC]
    void RPC_GetGoldAndXp(int GetXp, int GetGold){
		return;
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
                Debug.Log("Object " + champion.name +" is dead");
                //RespawnController.GetComponent<IRespawn>()?.Respawn();
                //Dying();
				if(attacker!=null){
					attacker.GetComponent<IDemagable>()?.GetGoldAndXp(giveXp, giveGold);
				}
                isHeroAlive=false;
                //heroCombatScript.targetedEnemy = null;
                //heroCombatScript.performMeleeAttack = false;
                PhotonNetwork.Destroy(champion);
            }
            
        }
    }

    
  
}
