﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script for the Character Stats page
// References : https://www.youtube.com/watch?v=aN11LnlF89I
// https://answers.unity.com/questions/1273054/change-text-value.html - change text
// https://stackoverflow.com/questions/6356351/formatting-a-float-to-2-decimal-places - 2 decimal places
public class MenuManager : MonoBehaviour
{

    // game object options menu
    public GameObject optionsMenu;
    public GameObject helpMenu;

    // referencing player health 
    public PlayerHealthScript playerHealth;

    public GameObject textBox1;
    public GameObject textBox2;
    public GameObject textBox3;
    public GameObject textBox4;

    public static float health = Mathf.Round(health * 100f) / 100f;
    public static int def;
    public static int dmg;
    public static int potion;
    public static float maxHp;

    void Start()
    {
        
    }
    
    void Update()
    {
        potion = PlayerHealthScript.potionCount;
        health = PlayerHealthScript.currentHealth;
        def = PlayerHealthScript.defense;
        dmg = PlayerHealthScript.damage;
        maxHp = PlayerHealthScript.maxHealth;

        // get text components and change them   
        textBox1.GetComponent<UnityEngine.UI.Text>().text = "Health : " + health.ToString("0.00") + " / " + maxHp.ToString("0.00");
        textBox2.GetComponent<UnityEngine.UI.Text>().text = "Damage : " + dmg.ToString();
        textBox3.GetComponent<UnityEngine.UI.Text>().text = "Defense : " + def.ToString();
        textBox4.GetComponent<UnityEngine.UI.Text>().text = "Potions : " + potion.ToString();

        // if press C, open character stats menu
        if (Input.GetKeyDown(KeyCode.C))
        {
            // always sets to opposite (true or false)
            optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
        }

        // if press I, open information menu
        if (Input.GetKeyDown(KeyCode.I))
        {
            // always sets to opposite (true or false)
            helpMenu.gameObject.SetActive(!helpMenu.gameObject.activeSelf);
        }

    }

}
