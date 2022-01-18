using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.AI;

public class GrayMinionBehaviour1 : MinionBehaviour
{
    //public NavMeshAgent agent;
    public GameObject GrayLineDst;
    public GameObject BrownLineDst;
    public GameObject GrayBase;
    public GameObject BrownBase;
    //Animator animator;

    private bool fisrtDestinationIsReached=false;
    

    

    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent> ();
       animator = GetComponent<Animator>();
       agent.autoRepath=true;
    }

    private void OnNetworkInstantiate() {
        agent.SetDestination(GrayLineDst.transform.position);
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
            if(!fisrtDestinationIsReached)
            {
                agent.SetDestination(GrayLineDst.transform.position);
                agent.isStopped=false;
                animator.SetBool("isWalking", true);
                destinationIsSet=true;
            }
            else 
            {
                agent.SetDestination(BrownBase.transform.position);
                agent.isStopped=false;
                animator.SetBool("isWalking", true);
                destinationIsSet=true;
            }

        }
        else if( agent.remainingDistance < 14)
            {
                agent.Stop();
                animator.SetBool("isWalking", false);
                fisrtDestinationIsReached=true;
                destinationIsSet=false;
                
            }

        
    }
}

    


