using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine;

public class CreateAndJoinRooms :MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    public static CreateAndJoinRooms room;
    public InputField createInput;
    public InputField joinInput;
    public int currentScene;
    public int multiplayerScene = 3;
    private PhotonView pv;

    private void Awake()
    {
        if(CreateAndJoinRooms.room==null)
        {
            CreateAndJoinRooms.room = this;
        }
        else
        {
            if(CreateAndJoinRooms.room!=this)
            {
                Destroy(CreateAndJoinRooms.room.gameObject);
                CreateAndJoinRooms.room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
        pv = GetComponent<PhotonView>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += onSceneFinishLoading;
    }

    public override void OnDisable()
    {
        base.OnEnable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= onSceneFinishLoading;
    }


    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions() { IsOpen = true, MaxPlayers = 6 };
        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
        }
    
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        int myNumberInRoom=PhotonNetwork.PlayerList.Length;
        Debug.Log("Connected to room");
        PhotonNetwork.NickName = myNumberInRoom.ToString();
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        PhotonNetwork.LoadLevel("DelayStartWaitingRoom");
        
    }
    void onSceneFinishLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.buildIndex;
        if(currentScene == multiplayerScene)
        {
            //createPlayer();
        }
    }

   // public void createPlayer()
    //{
     //   Vector3 position= new Vector3(760.323792F, 32.5F, 204.807297F);
    //    Quaternion rotation= new Quaternion(0F,0F,0F,1F);
        //PhotonNetwork.Instantiate("Robot Kyle", position , rotation ,0);
   // }

}
