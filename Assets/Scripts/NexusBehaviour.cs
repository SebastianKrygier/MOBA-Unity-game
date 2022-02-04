using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class NexusBehaviour : MonoBehaviour, IDemagable
{
    public PhotonView pv;
    [SerializeField]
    public float maxHealth;
    public float health;
    [SerializeField]
    public string Team;
    
    
    WhoWon winnerWhoWon;

    void Start()
    {
        health=maxHealth;
        pv=this.GetComponent<PhotonView>();
        winnerWhoWon= GameObject.Find("WhoWon").GetComponent<WhoWon>();
    }

    public void TakeDemage(float Demage, int pvId)
    {
        
        pv.RPC("RPC_TakeDemage", RpcTarget.All, Demage,pvId);
        Debug.Log("Hero attack take dmg sent");
    }

    public void GetGoldAndXp(int GetXp, int GetGold){
		return;
	}
    [PunRPC]
    void RPC_TakeDemage(float Demage, int pvId)
    {
        if(!pv.IsMine)
        {
            return;
        }
        health -= Demage;
        if (health <= 0)
        {
            if(pv.IsMine)
            {
                        Debug.Log("Nexus is dead.");
                        if(this.gameObject.tag=="Gray")
                        {
                            winnerWhoWon.BrownWon();
                        }
                        if(this.gameObject.tag=="Brown")
                        {
                            winnerWhoWon.GrayWon();
                        }
                        SceneManager.LoadScene("Ending");
            }
            
        }



    }
}
