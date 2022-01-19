using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WhoWon : MonoBehaviour
{

    public PhotonView pv;
    public string whoWon;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        pv = GetComponent<PhotonView>();
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
