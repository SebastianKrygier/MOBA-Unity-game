using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestMinionTargetting : Targetting
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
                                    Debug.Log(Minion.name + " is attacking " + combat.targetedEnemy.name );
                                }
                            }
                            else
                            {
                                
                                    behaviour.AfterAttack();
                                    Debug.Log("No enemy in " + Minion.name + "'s range. Getting back on track.");
                                    DidFought=false;
                            }   
                    }
                }
        
        
        
    }

    void OnTriggerEnter(Collider collider)
    {
        
            if (collider.gameObject.tag == "Gray")
            {
                //Debug.Log("wrog w zasiegu");
                EnemysInRange.Add(collider.gameObject);
                DidFought = true;
            }
            if (collider.gameObject.tag == "Brown")
            {
                //Debug.Log("wrog w zasiegu");
                EnemysInRange.Add(collider.gameObject);
                DidFought = true;
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