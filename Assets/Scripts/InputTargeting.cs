using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTargeting : MonoBehaviour
{

    public GameObject selectedHero;
    public bool heroPlayer;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        selectedHero = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.GetComponent<Targetable>() != null)
                {
                    if (hit.collider.gameObject.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
                    {
                        selectedHero.GetComponent<HeroCombat>().targetedEnemy = hit.collider.gameObject;
                    }
                }
            }
        }
    }
}
