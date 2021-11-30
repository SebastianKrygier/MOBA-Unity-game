using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using UnityEngine.Networking;

public class PlayerMove : MonoBehaviourPun
{

    public NavMeshAgent agent;
    Animator animator;

    public float rotateVelocity;
    public float rotateSpeedMovement;

    private HeroCombat heroCombatScript;

    void Start()
    {
        agent = GetComponent<NavMeshAgent> ();
        animator = GetComponent<Animator>();

        heroCombatScript = GetComponent<HeroCombat>();
    }

    void Update()
    {
        //COMBAT

        if (heroCombatScript.targetedEnemy != null)
        {
            if (heroCombatScript.targetedEnemy.GetComponent<HeroCombat>() != null)
            {
                if (!heroCombatScript.targetedEnemy.GetComponent<HeroCombat>().isHeroAlive)
                {
                    heroCombatScript.targetedEnemy = null;
                }
            }
        }

        //MOVING

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {

                if (hit.collider.tag == "Floor")
                {
                    agent.SetDestination(hit.point);

                    Quaternion rotationToLookAt = Quaternion.LookRotation(hit.transform.position - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);
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
        }

        //ANIMATIONS

        if(agent.velocity != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
        }
        else if(agent.velocity == Vector3.zero)
        {
            animator.SetBool("isWalking", false);
        }
    }
   


}

