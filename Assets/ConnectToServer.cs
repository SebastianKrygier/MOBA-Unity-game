using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon

public class ConnectToServer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
