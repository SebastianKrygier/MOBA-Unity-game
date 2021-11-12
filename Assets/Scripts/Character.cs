using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject character;
    bool team; // brown = 0, gery = 1
    public int level = 1;
    public int health = 100;
    public int mana = 100;
    public int move = 100;
    public int attack = 5;
    public int exp = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LevelUp()
    {
        if(exp > 100 && level < 10)
        {
            int helper = exp - 100;
            if (helper >= 0) exp = helper;
            level++;
        }
    }

    void Death()
    {
        if(health <= 0)
        {
            //todo
        }
    }
}
