using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon server.");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {

        SceneManager.LoadScene("lobby");
    }

}
