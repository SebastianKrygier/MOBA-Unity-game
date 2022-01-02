using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhotonNetwork;
using Photon.Pun;

public class MinionBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject GreyLineDst;
    public GameObject BrownLineDst;
    public GameObject GreyBase;
    public GameObject BrownBase;

    [SerializedField]
    private int LineIndicator;

    private bool firstDestinationIsSet=false;
    private bool fisrtDestinationIsReached=false;
    private bool secondDestinationIsSet=false;

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
        /*if(agent.velocity != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
        }
        if(!destinationIsSet)
        {
            if(!fisrtDestinationIsReached)
            {
                if(LineIndicator%2==0)
                {
                    agent.setDestination(GreyLineDst.position);
                }
                else if(LineIndicator%2==1)
                {
                    agent.setDestination(BrownLineDst.position);
                }
            }
        }
    }
    if(agent.remainingDistance<15)
            {
                agent.Stop();
                animator.SetBool("isWalking", false);
            }*/
    }
}
