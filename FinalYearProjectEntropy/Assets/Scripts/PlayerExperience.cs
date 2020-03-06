﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for Player Experience and Leveling
// References : https://forum.unity.com/threads/calling-function-from-other-scripts-c.57072/

public class PlayerExperience : MonoBehaviour
{
    PlayerHealthScript playerHp;
    PlayerHealthScript dmg;
    PlayerHealthScript def;
    HealthBarScr max;

    public EnemyStats die;
    bool dieTrue;

    public static float exp;
    public static float expToLevel = 100;

    public static int level = 1;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
              
        // player levels
        if (exp >= 100 && level == 1)
        {
            LevelUp();
            expToLevel = 130f;
            level += 1;
            exp = 0;
        }

        if (exp >= 130 && level == 2)
        {
            LevelUp();
            expToLevel = 170f;
            level += 1;
            exp = 0;

        }

        if (exp >= 170 && level == 3)
        {
            LevelUp();
            expToLevel = 220f;
            level += 1;
            exp = 0;

        }

        if (exp >= 220 && level == 4)
        {
            LevelUp();
            expToLevel = 300f;
            level += 1;
            exp = 0;

        }

        if(level == 5)
        {
            expToLevel = 0f;
            exp = 0;
        }

    }

    public void LevelUp()
    {
        // get variables to increase stats
        PlayerHealthScript.maxHealth += 30;
        PlayerHealthScript.currentHealth += 30;
        PlayerHealthScript.damage += 2;
        PlayerHealthScript.defense += 1;

        // set max health properly
        HealthBarScr.maxHp += PlayerHealthScript.maxHealth;

    }

}