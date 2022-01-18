using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using Photon.Pun;

public class TowerCombat : MonoBehaviour
{

    public enum HeroAttackType
    {
        Melee,
        Ranged
    };

    [SerializeField]
    public Targetting targetting;

    public HeroAttackType heroAttackType;

    private TowerBehaviour behaviour;

    public GameObject targetedEnemy;
    public float attackRange = 100;
    public float rotateSpeedForAttack;
    
    

   
    private ObjectStats statsScript;

    public bool basicAtkIdle = false;
   
    public bool performMeleeAttack = true;

    //
    public bool distance;
    //

    // Start is called before the first frame update
    void Start()
    {
        behaviour=GetComponent<TowerBehaviour>();
        statsScript = GetComponent<ObjectStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetedEnemy != null)
        {
            if (Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position) < attackRange)
            {
                if (heroAttackType == HeroAttackType.Melee)
                {
                    if (performMeleeAttack)
                    {
                        StartCoroutine(MeleeAttackInterval());
                    }
                }
            }
        }
    }

    IEnumerator MeleeAttackInterval()
    {
        performMeleeAttack = false;
        yield return new WaitForSeconds(statsScript.attackSpeed / ((100 + statsScript.attackSpeed) * 0.01f));
        MeleeAttack();
        //anim.SetBool("isAttacking", false);

        if (targetedEnemy == null)
        {
            performMeleeAttack = true;
        }
        
    }

    /*[PunRPC]
    void RPC_TargetDead(int pv)
    {
        if(PhotonView.Find(pv)!=targetedEnemy.GetComponent<PhotonView>())
        {
            return;
        }
        Debug.Log("Targeted enemy dead");
        GameObject ToDelete=PhotonView.Find(pv).gameObject;
        targetting.EnemysInRange.Remove(ToDelete);
        targetedEnemy=null;
    }
*/

    public void MeleeAttack()
    {
        
        if (targetedEnemy != null)
        {
            //if (targetedEnemy.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
            //{
            //anim.SetBool("isAttacking", true);
            /*if(targetedEnemy.GetComponent<ObjectStats>()!= null)
            {
                if (targetedEnemy.GetComponent<ObjectStats>().health - statsScript.attackDamage <= 0)
                {
                    //behaviour.OnTargetKill(targetedEnemy);
                    /*statsScript.Xp += targetedEnemy.GetComponent<Stats>().giveXp;
                    statsScript.Gold += targetedEnemy.GetComponent<Stats>().giveGold;
                }
            }
            else if(targetedEnemy.GetComponent<Stats>()!= null)
            {
                if (targetedEnemy.GetComponent<Stats>().health - statsScript.attackDamage <= 0)
                {
                    //behaviour.OnTargetKill(targetedEnemy);

                    /*statsScript.Xp += targetedEnemy.GetComponent<Stats>().giveXp;
                    statsScript.Gold += targetedEnemy.GetComponent<Stats>().giveGold;
                }

            }*/

            //}
            targetedEnemy.GetComponent<IDemagable>()?.TakeDemage(statsScript.attackDamage);

        }

        performMeleeAttack = true;
        //anim.SetBool("isAttacking", false);
    }
}

