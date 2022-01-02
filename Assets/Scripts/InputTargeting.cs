using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputTargeting : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject myHero;
    public GameObject selectedHero;
    public bool heroPlayer;
    private HeroCombat heroCombatScript;

    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        myHero = GameObject.FindGameObjectWithTag("Player");
        agent = myHero.GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Enemy")
                {

                    //if (hit.collider.gameObject.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
                    //{
                    selectedHero = hit.collider.gameObject;
                    myHero.GetComponent<HeroCombat>().targetedEnemy = selectedHero;
                    //}
                }
                else
                {
                    selectedHero = null;
                    myHero.GetComponent<HeroCombat>().targetedEnemy = null;
                }
            }
        }
    }

    private void onMouseEnterColor()
    {
        renderer.material.color = Color.red;
    }

    private void onMouseExitColor()
    {
        renderer.material.color = Color.white;
    }
}