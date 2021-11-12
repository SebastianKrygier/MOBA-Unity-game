using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using System.IO;
using Photon.Pun;

public class MainGame : MonoBehaviourPun
{
    public static MainGame game;

    public int playerCounter = 0;
    public GameObject[] SpawnBrown;
    public GameObject[] SpawnGray;
    


    // Start is called before the first frame update
    void Start()
    {
        game = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
