using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class DelayStartController : MonoBehaviourPunCallbacks
{
    private PhotonView myPhotonView;


    [SerializeField]
    private int multplayerSceneIndex;
    [SerializeField]
    private int menuSceneIndex;

    private int playerCount;
    private int roomSize;

    [SerializeField]
    private int minPlayersToStart;

    [SerializeField]
    private Text playerCountDisplay;
    [SerializeField]
    private Text timerToStart;

    private bool readyToCountDown;
    private bool readyToStart;
    private bool startingGame;

    private float timerToStartGame;
    private float notFullGameTimer;
    private float fullGameTimer;

    [SerializeField]
    private float maxWaitTime; 
    [SerializeField]
    private float maxFullGameWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        myPhotonView = GetComponent<PhotonView>();
        fullGameTimer = maxFullGameWaitTime;
        notFullGameTimer = maxWaitTime;
        timerToStart.text = maxWaitTime.ToString();

        PlayerCountUpdate();
        
    }

    void PlayerCountUpdate()
    {
        playerCount = PhotonNetwork.PlayerList.Length;
        roomSize = PhotonNetwork.CurrentRoom.MaxPlayers;
        playerCountDisplay.text = playerCount + ":" +roomSize;

        if(playerCount == roomSize)
        {
            readyToStart = true;
        }
        else if(playerCount >= minPlayersToStart)
        {
            readyToCountDown = true;
        }
        else
        {
            readyToCountDown = false;
            readyToStart = false;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PlayerCountUpdate();
        if(PhotonNetwork.IsMasterClient)
        {
            myPhotonView.RPC("RPC_SendTimer", RpcTarget.Others, timerToStartGame);
        }
    }
        [PunRPC]
        private void RPC_SendTimer(float timeIn)
        {
            timerToStartGame = timeIn;
            notFullGameTimer = timeIn;
            if(timeIn<fullGameTimer)
            {
                fullGameTimer = timeIn;
            }
        }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PlayerCountUpdate();
    }


    // Update is called once per frame
    void Update()
    {
        WaitingForMorePlayers();
    }

    void WaitingForMorePlayers()
    {
        if (playerCount <= minPlayersToStart)
        {
            ResetTimer();
        }
        if (readyToStart)
        {
            fullGameTimer -= Time.deltaTime;
            timerToStartGame = fullGameTimer;
        }
        else if (readyToCountDown)
        {
            notFullGameTimer -= Time.deltaTime;
            timerToStartGame = notFullGameTimer;

        }

        string tempTimer = string.Format("{0:00}", timerToStartGame);
        timerToStart.text = tempTimer;

        if(timerToStartGame <= 0)
        {
            if (startingGame)
                return;
            StartGame();
        }
    }

    void ResetTimer()
    {
        timerToStartGame = maxWaitTime;
        notFullGameTimer = maxWaitTime;
        fullGameTimer = maxFullGameWaitTime;
    }

    void StartGame()
    {
        startingGame = true;
        if (!PhotonNetwork.IsMasterClient)
            return;
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.LoadLevel(multplayerSceneIndex);
    }

    public void DelayCancel()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(menuSceneIndex);
    }
}
