using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerBehaviour : Targetting
{
    [SerializeField] public Collider Sphere;

    [SerializeField] public TowerCombat combat;

    [SerializeField] public GameObject Tower;

    private int EnemyCounter = 0;
    bool DidFought = false;


    void Start()
    {
        Sphere.isTrigger = true;
    }

    void Update(){
    
        if(combat.targetedEnemy==null)
                {
                    if(DidFought)
                        {
                            if(EnemysInRange.Count>0)
                            {
                                if(EnemysInRange[0]==null)
                                {
                                    EnemysInRange.RemoveAt(0);
                                }
                                else{
                                    combat.targetedEnemy=EnemysInRange[0];
                                    Debug.Log("Tower " + Tower.name + " is attacking " + combat.targetedEnemy);
                                }
                            }
                            else
                            {
                                    DidFought=false;
                            }   
                    }
                }
        
        
        
    }

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("cos jest w zasiegu");
        if (Tower.tag == "Brown")
        {
            if (collider.gameObject.tag == "Gray")
            {
                //Debug.Log("wrog w zasiegu");
                EnemysInRange.Add(collider.gameObject);
                DidFought = true;
            }
        }
        else if (Tower.tag == "Gray")
        {
            if (collider.gameObject.tag == "Brown")
            {
                //Debug.Log("wrog w zasiegu");
                EnemysInRange.Add(collider.gameObject);
                DidFought = true;
            }
        }
    }


    void OnTriggerExit(Collider collider)
    {
        if (combat.targetedEnemy == collider.gameObject)
        {
            combat.targetedEnemy = null;
        }

        EnemysInRange.Remove(collider.gameObject);
        EnemyCounter = 0;
    }
}