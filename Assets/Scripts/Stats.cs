using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Stats : MonoBehaviourPunCallbacks, IDemagable
{
    public GameObject champion;

    public PhotonView pv;

    public float maxHealth;
    public float health;
    public float attackDamage;
    public float attackSpeed;
    public float attackTime;
    public bool isHeroAlive=true;

    private HeroCombat heroCombatScript;

    // Start is called before the first frame update
    void Start()
    {
        //heroCombatScript = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroCombat>();
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
                isHeroAlive=false;
                //heroCombatScript.targetedEnemy = null;
                //heroCombatScript.performMeleeAttack = false;
                PhotonNetwork.Destroy(champion);
            }
            
        }
    }
}