using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionBehaviour : MonoBehaviour
{
    public bool destinationIsSet=false;
    
    public NavMeshAgent agent;
    public Animator animator;

   public void AfterAttack(){
        agent.isStopped=true;
        animator.SetBool("isWalking", false);
        destinationIsSet=false;
    }
}
