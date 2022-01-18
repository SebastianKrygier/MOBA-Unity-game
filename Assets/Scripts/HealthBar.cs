using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HealthBar : MonoBehaviour
    {

        
        [SerializeField]
        private GameObject healthBar;

        private GameObject healthBarDuplicate;
        public NavMeshAgent agent;

        private Stats statsScript;
        // private PhotonView pv;
        private Transform wholeBar; 
        private Transform greenBar;

        // Start is called before the first frame update
        void Start()
        {
            statsScript = GetComponent<Stats>();
            //pv = GetComponent<PhotonView>();
            agent = GetComponent<NavMeshAgent>();

            
            healthBarDuplicate = Instantiate(healthBar, agent.transform);
            greenBar = healthBarDuplicate.transform.GetChild(0).transform.GetChild(1);
            wholeBar = healthBarDuplicate.transform.GetChild(0);
            
        }

        void Update()           
        {
            wholeBar.transform.LookAt(Camera.main.transform);
            float health = statsScript.health / statsScript.maxHealth;
            greenBar.localScale = new Vector3(health, 1, 1);
          
        }
        
    }
}