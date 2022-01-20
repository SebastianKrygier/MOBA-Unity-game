using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class EndingWindowControler : MonoBehaviour
{
    [SerializeField]
    private GameObject Brown;
    [SerializeField]
    private GameObject Gray;
    [SerializeField]
    private int menuSceneIndex;
    
    private WhoWon winner;
    // Start is called before the first frame update
    void Start()
    {
        winner=GameObject.Find("WhoWon").GetComponent<WhoWon>();
        if(winner.whoWon=="Brown")
        {
            Gray.SetActive(false);
        }
        else if(winner.whoWon=="Gray")
        {
            Brown.SetActive(false);
        }

    }
    void Update(){
        if(winner.whoWon=="Brown")
        {
            Gray.SetActive(false);
        }
        else if(winner.whoWon=="Gray")
        {
            Brown.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Exit()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(menuSceneIndex);
    }
}
