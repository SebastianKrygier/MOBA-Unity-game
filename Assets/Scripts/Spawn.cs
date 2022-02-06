using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    int PlayersNumber=PhotonNetwork.PlayerList.Length;
    public GameObject BrownBase;
    public GameObject GrayBase;
    public GameObject Nest;
    public GameObject SpawnBrown;
    public GameObject SpawnGray;
    public GameObject SpawnBrownMinion;
    public GameObject SpawnGrayMinion;
    public GameObject player=null;
    public RespawnController PlayerRespawn=null;
    public GameObject Golem;


    [SerializeField]
    private float waitTimeForMinion;
    [SerializeField]
    bool TimeToSpawn=true;
    bool readyToStart=true;
    

    
    public GameObject Camera;

    public Vector3 offset;
    
    [SerializeField] private GameObject ForestMinion;
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject NexusPrefab1;
    [SerializeField] private GameObject NexusPrefab2;
    [SerializeField] private GameObject RespawnPrefab;
    [SerializeField] private GameObject prefab2;
    [SerializeField] private GameObject MinionGrayPrefab1;
    [SerializeField] private GameObject MinionGrayPrefab2;
    [SerializeField] private GameObject MinionBrownPrefab1;
    [SerializeField] private GameObject MinionBrownPrefab2;

    public float speed = 50;
    public float size = 10;
    private int counter=0;

    [SerializeField]
    private float InitialRespawnDelay;

    public void buyHealth()
    {
        
        PlayerRespawn.AddMaxHealth();
    }
    public void buyDemage()
    {
        
        PlayerRespawn.AddAttackDemage();
    }
    public void buyAS()
    {
       
       PlayerRespawn.AddAttackSpeed();
    }

    // Start is called before the first frame update
    void Start()
    {

        
        //GameObject player = PhotonNetwork.Instantiate("Robot Kyle", SpawnBrown[0].transform.position, SpawnBrown[0].transform.rotation,0);
        //player.GetComponent<PlayerMove>().enabled = true;
        //player.GetComponent<Animator>().enabled = true;
        /*if (PhotonNetwork.NickName == "1")
        {
            player = PhotonNetwork.Instantiate(prefab1.name, SpawnBrown.transform.position, SpawnBrown.transform.rotation,0);
        }
        else if(PhotonNetwork.NickName == "2")
        {
            player = PhotonNetwork.Instantiate(prefab2.name, SpawnGray.transform.position, SpawnGray.transform.rotation,0);
        }
        else if(PhotonNetwork.NickName == "3")
        {
            player = PhotonNetwork.Instantiate(prefab1.name, SpawnBrown.transform.position, SpawnBrown.transform.rotation,0);
        }
        else if(PhotonNetwork.NickName == "4")
        {
            player = PhotonNetwork.Instantiate(prefab2.name, SpawnGray.transform.position, SpawnGray.transform.rotation,0);
        }
        else if(PhotonNetwork.NickName == "5")
        {
            player = PhotonNetwork.Instantiate(prefab1.name, SpawnBrown.transform.position, SpawnBrown.transform.rotation,0);
        }
        else if(PhotonNetwork.NickName == "6")
        {
            player = PhotonNetwork.Instantiate(prefab2.name, SpawnGray.transform.position, SpawnGray.transform.rotation,0);
        }
        player.GetComponent<PlayerMove>().enabled = true;*/
        player=PhotonNetwork.Instantiate(RespawnPrefab.name, SpawnGray.transform.position, SpawnGray.transform.rotation,0);
        PlayerRespawn=player.GetComponent<RespawnController>();
        PlayerRespawn.Respawn();
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(NexusPrefab1.name, GrayBase.transform.position, GrayBase.transform.rotation,0);
            PhotonNetwork.Instantiate(NexusPrefab2.name, BrownBase.transform.position, BrownBase.transform.rotation,0);
            Golem=(GameObject) PhotonNetwork.Instantiate(ForestMinion.name, Nest.transform.position, Nest.transform.rotation,0);
        }
        if (PhotonNetwork.NickName == "1"||PhotonNetwork.NickName == "3"||PhotonNetwork.NickName == "5")
        {
            Camera.transform.position=SpawnBrown.transform.position+offset;
        }
        else
        {
            Camera.transform.position=SpawnGray.transform.position+offset;
        }
        

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      /*  if(player != null && Camera != null)
        {
                Vector3 position = Camera.transform.position;
            if(Camera.transform.position.z<650){
                if (Input.mousePosition.y >= Screen.height - size) // move up
                {
                    position.z += speed * Time.deltaTime;
                }
            }
             if(Camera.transform.position.z>35){
                if (Input.mousePosition.y <= size) // move down
                {
                    position.z -= speed * Time.deltaTime;
                }
             }
            if(Camera.transform.position.x<595){
                if (Input.mousePosition.x >= Screen.width - size) // move right
                {
                    position.x += speed * Time.deltaTime;
                }
            }
            if(Camera.transform.position.x>380){
                if (Input.mousePosition.x <= size) // move left
                {
                    position.x -= speed * Time.deltaTime;
                }
            }

            Camera.transform.position = position;
        }*/
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        if(TimeToSpawn)
        {
            
                if(readyToStart && counter==0)
                {
                    PhotonNetwork.Instantiate(MinionBrownPrefab1.name, SpawnBrownMinion.transform.position, SpawnBrownMinion.transform.rotation,0);
                    readyToStart=false;
                    counter++;
                    StartCoroutine(smallWaiter());
                }
                   
                if(readyToStart&& counter==1)
                {
                    PhotonNetwork.Instantiate(MinionGrayPrefab1.name, SpawnGrayMinion.transform.position, SpawnGrayMinion.transform.rotation,0);
                    readyToStart=false;
                    counter++;
                    StartCoroutine(smallWaiter());
                }

                if(readyToStart&& counter==2)
                {
                   
                    PhotonNetwork.Instantiate(MinionBrownPrefab2.name, SpawnBrownMinion.transform.position, SpawnBrownMinion.transform.rotation,0);
                    readyToStart=false;
                    counter++;
                    StartCoroutine(smallWaiter());
                }
         
                if(readyToStart&& counter==3)
                {
                    
                   PhotonNetwork.Instantiate(MinionGrayPrefab2.name, SpawnGrayMinion.transform.position, SpawnGrayMinion.transform.rotation,0);
                   readyToStart=false;
                    counter++;
                    StartCoroutine(smallWaiter());
                }
                if(readyToStart && counter==4)
                {
                    PhotonNetwork.Instantiate(MinionBrownPrefab1.name, SpawnBrownMinion.transform.position, SpawnBrownMinion.transform.rotation,0);
                    readyToStart=false;
                    counter++;
                    StartCoroutine(smallWaiter());
                }
                   
                if(readyToStart&& counter==5)
                {
                    PhotonNetwork.Instantiate(MinionGrayPrefab1.name, SpawnGrayMinion.transform.position, SpawnGrayMinion.transform.rotation,0);
                    readyToStart=false;
                    counter++;
                    StartCoroutine(smallWaiter());
                }

                if(readyToStart&& counter==6)
                {
                   
                    PhotonNetwork.Instantiate(MinionBrownPrefab2.name, SpawnBrownMinion.transform.position, SpawnBrownMinion.transform.rotation,0);
                    readyToStart=false;
                    counter++;
                    StartCoroutine(smallWaiter());
                }
         
                if(readyToStart&& counter==7)
                {
                    
                   PhotonNetwork.Instantiate(MinionGrayPrefab2.name, SpawnGrayMinion.transform.position, SpawnGrayMinion.transform.rotation,0);
                   readyToStart=false;
                    counter++;
                    StartCoroutine(smallWaiter());
                }
                if(readyToStart && counter==8)
                {
                    PhotonNetwork.Instantiate(MinionBrownPrefab1.name, SpawnBrownMinion.transform.position, SpawnBrownMinion.transform.rotation,0);
                    readyToStart=false;
                    counter++;
                    StartCoroutine(smallWaiter());
                }
                   
                if(readyToStart&& counter==9)
                {
                    PhotonNetwork.Instantiate(MinionGrayPrefab1.name, SpawnGrayMinion.transform.position, SpawnGrayMinion.transform.rotation,0);
                    readyToStart=false;
                    counter++;
                    StartCoroutine(smallWaiter());
                }

                if(readyToStart&& counter==10)
                {
                   
                    PhotonNetwork.Instantiate(MinionBrownPrefab2.name, SpawnBrownMinion.transform.position, SpawnBrownMinion.transform.rotation,0);
                    readyToStart=false;
                    counter++;
                    StartCoroutine(smallWaiter());
                }
         
                if(readyToStart&& counter==11)
                {
                    
                   PhotonNetwork.Instantiate(MinionGrayPrefab2.name, SpawnGrayMinion.transform.position, SpawnGrayMinion.transform.rotation,0);
                   TimeToSpawn=false;
                   if( Golem == null&& counter==11)
                    {
                        Golem=(GameObject) PhotonNetwork.Instantiate(ForestMinion.name, Nest.transform.position, Nest.transform.rotation,0);

                    }
                   StartCoroutine(waiter());
                }

                
                
        }
        


    }


    IEnumerator smallWaiter()
    {
        yield return new WaitForSeconds(InitialRespawnDelay);
        readyToStart=true;

    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(waitTimeForMinion);
        TimeToSpawn=true;
        counter=0;

    }
    void Update()
    { 
        
    }
}
