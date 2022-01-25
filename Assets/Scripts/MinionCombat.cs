using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using Photon.Pun;

public class MinionCombat : MonoBehaviour
{

    public enum HeroAttackType
    {
        Melee,
        Ranged
    };

    public HeroAttackType heroAttackType;

    public GameObject targetedEnemy;
    public float attackRange = 100;
    public float rotateSpeedForAttack;
    public NavMeshAgent agent;
    [SerializeField]
    public Targetting targetting;
    

   
    private ObjectStats statsScript;
    private Animator anim;

    public bool basicAtkIdle = false;
   
    public bool performMeleeAttack = true;

    //
    public bool distance;
    //

    // Start is called before the first frame update
    void Start()
    {
        statsScript = GetComponent<ObjectStats>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetedEnemy != null)
        {

            if (Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position) > attackRange)
            {
                anim.SetBool("isAttacking", false);
                agent.isStopped=false;
                agent.SetDestination(targetedEnemy.transform.position);
                agent.stoppingDistance = attackRange;

                Quaternion rotationToLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);
                //float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref agent.rotateVelocity, rotateSpeedForAttack * (Time.deltaTime * 5));

                //transform.eulerAngles = new Vector3(0, rotationY, 0);
            }
            else
            {
                if (heroAttackType == HeroAttackType.Melee)
                {
                    if (performMeleeAttack)
                    {
                        //Debug.Log("Attack the Minion");
                        StartCoroutine(MeleeAttackInterval());
                    }
                }
            }
        }
    }

    IEnumerator MeleeAttackInterval()
    {
        performMeleeAttack = false;
        anim.SetBool("isAttacking", true);
        yield return new WaitForSeconds(statsScript.attackSpeed / ((100 + statsScript.attackSpeed) * 0.01f));
        MeleeAttack();
        //anim.SetBool("isAttacking", false);

        if (targetedEnemy == null)
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", false);
            performMeleeAttack = true;
        }
        
    }

    [PunRPC]
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

    public void MeleeAttack()
    {
        if (targetedEnemy != null)
        {
            //if (targetedEnemy.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
            //{
            //anim.SetBool("isAttacking", true);
           /* if(targetedEnemy.GetComponent<ObjectStats>()!= null)
            {
                if (targetedEnemy.GetComponent<ObjectStats>().health - statsScript.attackDamage <= 0)
                {
                    statsScript.Xp += targetedEnemy.GetComponent<Stats>().giveXp;
                    statsScript.Gold += targetedEnemy.GetComponent<Stats>().giveGold;
                }
            }
            else if(targetedEnemy.GetComponent<Stats>()!= null)
            {
                if (targetedEnemy.GetComponent<Stats>().health - statsScript.attackDamage <= 0)
                {
                    statsScript.Xp += targetedEnemy.GetComponent<Stats>().giveXp;
                    statsScript.Gold += targetedEnemy.GetComponent<Stats>().giveGold;
                }

            }*/

            targetedEnemy.GetComponent<IDemagable>()?.TakeDemage(statsScript.attackDamage);
            //}
        }

        performMeleeAttack = true;
        //anim.SetBool("isAttacking", false);
    }
}
