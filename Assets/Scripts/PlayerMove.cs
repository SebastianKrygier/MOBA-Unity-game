using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;


public class PlayerMove : MonoBehaviourPun
{

    private bool clickFlag;

    public NavMeshAgent agent;
    Animator animator;
    public GameObject selectedHero;
    public GameObject myHero;
   

    public PhotonView pv;

    public LayerMask WhatCanBeClicked;

    public float rotateVelocity;
    public float rotateSpeedMovement;

    private HeroCombat heroCombatScript;
    public Stats statsScript;

    void Start()
    {
        pv=GetComponent<PhotonView>();
        agent = GetComponent<NavMeshAgent> ();
        animator = GetComponent<Animator>();
        statsScript = GetComponent<Stats>();
        heroCombatScript = GetComponent<HeroCombat>();
        
    }

    [System.Obsolete]
    void Update()
    {
        
        //COMBAT

        if (heroCombatScript.targetedEnemy != null)
        {
            if (heroCombatScript.targetedEnemy.GetComponent<Stats>() != null)
            {
                if (!heroCombatScript.targetedEnemy.GetComponent<Stats>().isHeroAlive)
                {
                    heroCombatScript.targetedEnemy = null;
                }
            }
        }

        //MOVING
        RaycastHit hit;
        Vector3 dest=Vector3.zero;

        if(pv.IsMine){
            if (Input.GetMouseButtonDown(1) || clickFlag)
            {

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, WhatCanBeClicked))
                {

                    if (hit.collider.tag == "Floor")
                    {
                            heroCombatScript.targetedEnemy = null;
                            animator.SetBool("isAttacking", false);
                        
                            agent.Resume();
                            agent.SetDestination(hit.point);
                            myHero.GetComponent<HeroCombat>().targetedEnemy = null;
                        
                        //Quaternion rotationToLookAt = Quaternion.LookRotation(hit.transform.position - transform.position);
                        //float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));

                        //transform.eulerAngles = new Vector3(0, rotationY, 0);

                    }
                    
                }

                /*
                var velocity = Vector3.forward * 2;
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    agent.SetDestination(hit.point);
                    transform.Translate(velocity * Time.deltaTime);
                }
                    */
                if(clickFlag)
                {
                    clickFlag =false;
                    Debug.Log("Hero is walking to " + hit.point);
                }
                else
                {
                    clickFlag=true;
                }
            }
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if(statsScript.Team=="Brown")
                {
                    if (hit.collider.tag == "Gray" )
                    {

                        //if (hit.collider.gameObject.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
                        //{
                        selectedHero = hit.collider.gameObject;
                        myHero.GetComponent<HeroCombat>().targetedEnemy = selectedHero;
                        
                        //animator.SetBool("isAttacking", true);
                        //}
                        Debug.Log("Hero is attacking " + selectedHero.name);
                    }
                    else if (hit.collider.tag == "Forest" )
                    {

                        //if (hit.collider.gameObject.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
                        //{
                        selectedHero = hit.collider.gameObject;
                        myHero.GetComponent<HeroCombat>().targetedEnemy = selectedHero;
                        
                        //animator.SetBool("isAttacking", true);
                        //}
                        Debug.Log("Hero is attacking " + selectedHero.name);
                    }
                    else
                    {
                        selectedHero = null;
                        myHero.GetComponent<HeroCombat>().targetedEnemy = null;
                        
                    }
                }
                if(statsScript.Team =="Gray")
                {
                    if (hit.collider.tag == "Brown" || hit.collider.tag == "Forest")
                    {

                        //if (hit.collider.gameObject.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
                        //{
                        selectedHero = hit.collider.gameObject;
                        myHero.GetComponent<HeroCombat>().targetedEnemy = selectedHero;
                        Debug.Log("Hero is attacking " + selectedHero.name);

                        
                        //animator.SetBool("isAttacking", true);
                        //}
                    }
                    
                    else
                    {
                        selectedHero = null;
                        myHero.GetComponent<HeroCombat>().targetedEnemy = null;
                        
                    }
                }
            }
        }
        }

        //ANIMATIONS



        if(agent.velocity != Vector3.zero)
        {
            animator.SetBool("IsWalking", true);
        }

        if(agent.remainingDistance<15)
            {
                agent.Stop();
               // agent.ResetPath();

                animator.SetBool("IsWalking", false);
            }
        
            
        
        
        
    }
   


}

