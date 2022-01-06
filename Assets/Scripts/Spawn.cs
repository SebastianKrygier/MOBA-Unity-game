using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    int PlayersNumber=PhotonNetwork.PlayerList.Length;
    public GameObject SpawnBrown;
    public GameObject SpawnGrey;
    public GameObject SpawnBrownMinion;
    public GameObject SpawnGreyMinion;
    public GameObject player=null;
     [SerializeField]
    private object[] LineIndicator= new object[]{0};

    [SerializeField]
    private object[] BrownTeamIndicator= new object[]{0};
    [SerializeField]
    private object[] GreyTeamIndicator= new object[]{1};



    List<GameObject> listOfBrownMinions;
    List<GameObject> listOfGreyMinions;


    [SerializeField]
    private float waitTimeForMinion;

    private float sinceMinionArrived=0.0f;

    [SerializeField]
    private float spawnInterval;
    
    private float spawnDelay=0.0f;
    public GameObject Camera;

    public Vector3 offset;
    
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;
    [SerializeField] private GameObject MinionGreyPrefab;
    [SerializeField] private GameObject MinionBrownPrefab;
    public float speed = 25;
    public float size = 10;


    // Start is called before the first frame update
    void Start()
    {

        
        //GameObject player = PhotonNetwork.Instantiate("Robot Kyle", SpawnBrown[0].transform.position, SpawnBrown[0].transform.rotation,0);
        //player.GetComponent<PlayerMove>().enabled = true;
        //player.GetComponent<Animator>().enabled = true;
        if (PhotonNetwork.NickName == "1")
        {
            player = PhotonNetwork.Instantiate(prefab1.name, SpawnBrown.transform.position, SpawnBrown.transform.rotation,0,BrownTeamIndicator);
        }
        else if(PhotonNetwork.NickName == "2")
        {
            player = PhotonNetwork.Instantiate(prefab2.name, SpawnGrey.transform.position, SpawnGrey.transform.rotation,0, GreyTeamIndicator);
        }
        else if(PhotonNetwork.NickName == "3")
        {
            player = PhotonNetwork.Instantiate(prefab1.name, SpawnBrown.transform.position, SpawnBrown.transform.rotation,0,BrownTeamIndicator);
        }
        else if(PhotonNetwork.NickName == "4")
        {
            player = PhotonNetwork.Instantiate(prefab2.name, SpawnGrey.transform.position, SpawnGrey.transform.rotation,0, GreyTeamIndicator);
        }
        else if(PhotonNetwork.NickName == "5")
        {
            player = PhotonNetwork.Instantiate(prefab1.name, SpawnBrown.transform.position, SpawnBrown.transform.rotation,0,BrownTeamIndicator);
        }
        else if(PhotonNetwork.NickName == "6")
        {
            player = PhotonNetwork.Instantiate(prefab2.name, SpawnGrey.transform.position, SpawnGrey.transform.rotation,0, GreyTeamIndicator);
        }
        player.GetComponent<PlayerMove>().enabled = true;
        Camera.transform.position=player.transform.position+offset;
        
        PhotonNetwork.Instantiate(MinionBrownPrefab.name, SpawnBrownMinion.transform.position, SpawnBrownMinion.transform.rotation,0);
        PhotonNetwork.Instantiate(MinionGreyPrefab.name, SpawnGreyMinion.transform.position, SpawnGreyMinion.transform.rotation,0);
        PhotonNetwork.Instantiate(MinionBrownPrefab.name, SpawnBrownMinion.transform.position, SpawnBrownMinion.transform.rotation,1);
        PhotonNetwork.Instantiate(MinionGreyPrefab.name, SpawnGreyMinion.transform.position, SpawnGreyMinion.transform.rotation,1);

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player != null && Camera != null)
        {
                Vector3 position = Camera.transform.position;

            if (Input.mousePosition.y >= Screen.height - size) // move up
            {
                position.z += speed * Time.deltaTime;
            }

            if (Input.mousePosition.y <= size) // move down
            {
                position.z -= speed * Time.deltaTime;
            }

            if (Input.mousePosition.x >= Screen.width - size) // move right
            {
                position.x += speed * Time.deltaTime;
            }

            if (Input.mousePosition.x <= size) // move left
            {
                position.x -= speed * Time.deltaTime;
            }

            Camera.transform.position = position;
        }
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        /*if(waitTimeForMinion<sinceMinionArrived)
        {
            for(int i=0; i<1; i++)
            {
                listOfBrownMinions.Add((GameObject)PhotonNetwork.Instantiate(MinionBrownPrefab.name, SpawnBrownMinion.transform.position, SpawnBrownMinion.transform.rotation,0));
                listOfGreyMinions.Add((GameObject)PhotonNetwork.Instantiate(MinionGreyPrefab.name, SpawnGreyMinion.transform.position, SpawnGreyMinion.transform.rotation,0));
                listOfBrownMinions.Add((GameObject)PhotonNetwork.Instantiate(MinionBrownPrefab.name, SpawnBrownMinion.transform.position, SpawnBrownMinion.transform.rotation,1));
                listOfGreyMinions.Add((GameObject)PhotonNetwork.Instantiate(MinionGreyPrefab.name, SpawnGreyMinion.transform.position, SpawnGreyMinion.transform.rotation,1));
                while(spawnInterval>spawnDelay)
                {
                    spawnDelay+=Time.deltaTime;
                }
                spawnDelay=0.0f;
            }
            sinceMinionArrived=0.0f;
        }
        else
        {
            sinceMinionArrived+=Time.deltaTime;
        }*/


    }
    void Update()
    { 
        
    }
}
