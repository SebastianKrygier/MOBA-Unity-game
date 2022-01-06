using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    int PlayersNumber=PhotonNetwork.PlayerList.Length;
    public GameObject SpawnBrown;
    public GameObject SpawnGray;
    public GameObject SpawnBrownMinion;
    public GameObject SpawnGrayMinion;
    public GameObject player=null;


    [SerializeField]
    private float waitTimeForMinion;
    bool TimeToSpawn=true;
    

    
    public GameObject Camera;

    public Vector3 offset;
    
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;
    [SerializeField] private GameObject MinionGrayPrefab;
    [SerializeField] private GameObject MinionBrownPrefab;
    public float speed = 40;
    public float size = 10;


    // Start is called before the first frame update
    void Start()
    {

        
        //GameObject player = PhotonNetwork.Instantiate("Robot Kyle", SpawnBrown[0].transform.position, SpawnBrown[0].transform.rotation,0);
        //player.GetComponent<PlayerMove>().enabled = true;
        //player.GetComponent<Animator>().enabled = true;
        if (PhotonNetwork.NickName == "1")
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
        player.GetComponent<PlayerMove>().enabled = true;
        Camera.transform.position=player.transform.position+offset;
        
        

        
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
        if(TimeToSpawn)
        {
            for(int i=0; i<3; i++)
            {
                TimeToSpawn=false;
                PhotonNetwork.Instantiate(MinionBrownPrefab.name, SpawnBrownMinion.transform.position, SpawnBrownMinion.transform.rotation,0);
                PhotonNetwork.Instantiate(MinionGrayPrefab.name, SpawnGrayMinion.transform.position, SpawnGrayMinion.transform.rotation,0);
                PhotonNetwork.Instantiate(MinionBrownPrefab.name, SpawnBrownMinion.transform.position, SpawnBrownMinion.transform.rotation,0);
                PhotonNetwork.Instantiate(MinionGrayPrefab.name, SpawnGrayMinion.transform.position, SpawnGrayMinion.transform.rotation,0);
                waiter();
                
            }
        }
        


    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(waitTimeForMinion);
        TimeToSpawn=true;

    }
    void Update()
    { 
        
    }
}
