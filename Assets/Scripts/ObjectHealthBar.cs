using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ObjectHealthBar : MonoBehaviour
    {


        [SerializeField]
        private GameObject healthBar;

        private GameObject healthBarDuplicate;
        public SphereCollider sphere;

        private ObjectStats statsScript;
        // private PhotonView pv;
        private Transform wholeBar;
        private Transform greenBar;

        // Start is called before the first frame update
        void Start()
        {
            statsScript = GetComponent<ObjectStats>();
            //pv = GetComponent<PhotonView>();
            //healthBar = GetComponent<Image>();
            sphere = GetComponent<SphereCollider>();


            healthBarDuplicate = Instantiate(healthBar, sphere.transform);
            healthBarDuplicate.transform.position += new Vector3(0, 35, 0);
            greenBar = healthBarDuplicate.transform.GetChild(0).transform.GetChild(1);
            wholeBar = healthBarDuplicate.transform.GetChild(0);

        }

        // Update is called once per frame
        void Update()
        {

            //if (!pv.IsMine) return;
            wholeBar.transform.LookAt(Camera.main.transform);
            float health = statsScript.health / statsScript.maxHealth;
            greenBar.localScale = new Vector3(health, 1, 1);

        }

    }
}