using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.AI;

public class MinionBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject GreyLineDst;
    public GameObject BrownLineDst;
    public GameObject GreyBase;
    public GameObject BrownBase;
    Animator animator;

    [SerializeField]
    private object[] LineIndicator= new object[]{0};

    private bool fisrtDestinationIsReached=false;
    private bool destinationIsSet=false;

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        LineIndicator = info.photonView.InstantiationData;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
                if((int)LineIndicator[0]==0)
                {
                    agent.SetDestination(GreyLineDst.transform.position);
                }
                else
                {
                    agent.SetDestination(BrownLineDst.transform.position);

                }
                destinationIsSet=true;
            }
            else
            {
                if((int)LineIndicator[0]==0)
                {
                    agent.SetDestination(GreyBase.transform.position);
                }
                else if((int)LineIndicator[0]==1)
                {
                    agent.SetDestination(BrownBase.transform.position);
                }
                agent.Resume();
                destinationIsSet=true;
            }
        }
        if(agent.remainingDistance<15)
            {
                agent.Stop();
                animator.SetBool("isWalking", false);
                 destinationIsSet=false;
                fisrtDestinationIsReached=true;
            }

        
    }
}
    

