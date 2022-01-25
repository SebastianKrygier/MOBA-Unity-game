using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.AI;

public class ForestMinionBehaviour : MinionBehaviour
{
    //public NavMeshAgent agent;
    
    public GameObject Nest;
    //Animator animator;

    

    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent> ();
       animator = GetComponent<Animator>();
       agent.autoRepath=true;
    }

    private void OnNetworkInstantiate() {
        //agent.SetDestination(Nest.transform.position);
        destinationIsSet=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.velocity != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
        }
        
        
        if(!destinationIsSet)
        {
           
                agent.SetDestination(Nest.transform.position);
                agent.isStopped=false;
                animator.SetBool("isWalking", true);
                destinationIsSet=true;
           
        }
        else if(destinationIsSet)
            {
                if( agent.remainingDistance < 20)
                {
                    agent.isStopped=true;
                    animator.SetBool("isWalking", false);
                }
            }
                
        

        
    }

    


         
}