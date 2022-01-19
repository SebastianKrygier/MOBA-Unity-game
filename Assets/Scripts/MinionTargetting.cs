using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinionTargetting : Targetting
{
    [SerializeField] public Collider Sphere;
    public MinionBehaviour behaviour;

    [SerializeField] public MinionCombat combat;

    [SerializeField] public GameObject Minion;
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
                                }
                            }
                            else
                            {
                                
                                    behaviour.AfterAttack();
                                    DidFought=false;
                            }   
                    }
                }
        
        
        
    }

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("cos jest w zasiegu");
        if (Minion.tag == "Brown")
        {
            if (collider.gameObject.tag == "Gray")
            {
                //Debug.Log("wrog w zasiegu");
                EnemysInRange.Add(collider.gameObject);
                DidFought = true;
            }
        }
        else if (Minion.tag == "Gray")
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