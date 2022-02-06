using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviourPun
{

    public Stats statsScript;

    public PhotonView pv;

    public Transform hpBar;
    public Transform manaBar;
    public Transform xpBar;

    [SerializeField]
    private Text hpText;
    [SerializeField]
    private Text manaText;
    [SerializeField]
    private Text xpText;

    private double hp;
    private double mana;
    private double xp;
    private int gold;
    private int level;
	private int XpForLevel;

    [SerializeField]
    private Text goldText;
    [SerializeField]
    private Text levelText;

    public Button DmgButton;
    public Button AsButton;
    public Button HpButton;


    void Start()
    {
        pv = GetComponent<PhotonView>();
        statsScript = GetComponent<Stats>();

        hpBar = GameObject.Find("HUD/Health/Bar").transform;
        manaBar = GameObject.Find("HUD/Mana/Bar").transform;
        xpBar = GameObject.Find("HUD/XP/Bar").transform;

        hpText = GameObject.Find("HUD/Health/Value").GetComponent<Text>();
        manaText = GameObject.Find("HUD/Mana/Value").GetComponent<Text>();
        xpText = GameObject.Find("HUD/XP/Value").GetComponent<Text>();
        goldText = GameObject.Find("HUD/Shop/GoldAmmount").GetComponent<Text>();
        levelText = GameObject.Find("HUD/XP/Level/Number").GetComponent<Text>();

        DmgButton = GameObject.Find("HUD/Shop/DmgButton").GetComponent<Button>();
        AsButton = GameObject.Find("HUD/Shop/AsButton").GetComponent<Button>();
        HpButton = GameObject.Find("HUD/Shop/HpButton").GetComponent<Button>();


        hp = statsScript.health;
        mana = statsScript.Mana;
        xp = statsScript.Xp;
		XpForLevel=statsScript.XpForLvl;
		level=statsScript.level;
 	hpBar.localScale = new Vector3((float)(hp/statsScript.maxHealth), 1, 1);
        manaBar.localScale = new Vector3((float)(mana/100), 1, 1);
        xpBar.localScale = new Vector3((float)(xp/XpForLevel), 1, 1);


    }

    
    void Update()
    {

        if (pv.IsMine)
        {
            hp = statsScript.health;
            mana = statsScript.Mana;
            xp = statsScript.Xp;
			XpForLevel=statsScript.XpForLvl;
            gold = statsScript.Gold;
            level = statsScript.level;

            hpBar.localScale = new Vector3((float)(hp/(statsScript.maxHealth)), 1, 1);
            manaBar.localScale = new Vector3((float)(mana/100), 1, 1);
            xpBar.localScale = new Vector3((float)(xp/XpForLevel), 1, 1);

            hpText.text = hp.ToString();
            manaText.text = mana.ToString();
            xpText.text = xp.ToString();
            goldText.text = gold.ToString();
            levelText.text = level.ToString();
        }
    }

    public void Buy(int item)
    {
        if (statsScript.Gold >= 1000)
        {
            switch (item)
            {
                case 1:
                    DmgButton.interactable = false;
                    statsScript.attackDamage += 30;
                    statsScript.Gold -= 1000;
                    break;

                case 2:
                    AsButton.interactable = false;
                    statsScript.attackSpeed = statsScript.attackSpeed * 8 / 10;
                    statsScript.Gold -= 1000;
                    break;

                case 3:
                    HpButton.interactable = false;
                    statsScript.maxHealth += 30;
                    if (statsScript.health < statsScript.maxHealth)
                    {
                        if (statsScript.health + 30 < statsScript.maxHealth) statsScript.health += 30;
                        else statsScript.health = statsScript.maxHealth;
                    }
                    statsScript.Gold -= 1000;
                    break;

                default:
                    break;
            }
        }
    }
}
