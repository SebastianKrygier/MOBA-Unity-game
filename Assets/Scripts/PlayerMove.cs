using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class PlayerMove : MonoBehaviourPun
{

    NavMeshAgent agent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent> ();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(1))
            {
                var velocity = Vector3.forward * 2;
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    agent.SetDestination(hit.point);
                    transform.Translate(velocity * Time.deltaTime);
                }
            }

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

