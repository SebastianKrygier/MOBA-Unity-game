using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ShopButton : MonoBehaviourPun
{

    public PhotonView pv;

    [SerializeField]
    private int action; // 1 - dmg / 2 - as / 3 - hp

    [SerializeField]
    private Spawn spawn;


    /*
    void Buy()
    { 
        pv = GetComponent<PhotonView>();

        if (pv.IsMine)
        {
            //pv.GetComponent<IBuy>()?.Buy(action);

            if (spawn.respawnCotrollerObject.Gold >= 1000)
            {
                switch (action)
                {
                    case 1:
                        spawn.respawnCotrollerObject.attackDamage += 30;
                        spawn.respawnCotrollerObject.Gold -= 1000;
                        break;

                    case 2:
                        spawn.respawnCotrollerObject.attackSpeed = spawn.respawnCotrollerObject.attackSpeed * 8 / 10;
                        spawn.respawnCotrollerObject.Gold -= 1000;
                        break;

                    case 3:
                        spawn.respawnCotrollerObject.maxHealth += 30;
                        if (spawn.respawnCotrollerObject.health < spawn.respawnCotrollerObject.maxHealth)
                        {
                            if (spawn.respawnCotrollerObject.health + 30 < spawn.respawnCotrollerObject.maxHealth) spawn.respawnCotrollerObject.health += 30;
                            else spawn.respawnCotrollerObject.health = spawn.respawnCotrollerObject.maxHealth;
                        }
                        spawn.respawnCotrollerObject.Gold -= 1000;
                        break;

                    default:
                        break;
                }
            }
        }
    }
    */
}
