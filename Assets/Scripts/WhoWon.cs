using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class WhoWon : MonoBehaviour, IPunObservable
{
    
    public static WhoWon winner;
    public PhotonView pv;
    [SerializeField]
    public string whoWon;
      private void Awake()
    {
        if(WhoWon.winner==null)
        {
            WhoWon.winner = this;
        }
        else
        {
            if(WhoWon.winner!=this)
            {
                Destroy(WhoWon.winner.gameObject);
                WhoWon.winner = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
        pv = GetComponent<PhotonView>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(whoWon);
        }
        else
        {
            whoWon = (string)stream.ReceiveNext();
        }
    }

    public void BrownWon()
    {
        
        whoWon="Brown";
    }

    

    public void GrayWon()
    {
        
        whoWon="Gray";
    }

    
}
