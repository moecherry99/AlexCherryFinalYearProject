using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script for the Character Stats page
// References : https://www.youtube.com/watch?v=aN11LnlF89I
// https://answers.unity.com/questions/1273054/change-text-value.html
public class MenuManager : MonoBehaviour
{

    // game object options menu
    public GameObject optionsMenu;

    // referencing player health 
    public PlayerHealthScript playerHealth;

    public GameObject textBox1;
    public GameObject textBox2;
    public GameObject textBox3;

    public static int health;
    public static int def;
    public static int dmg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        health = PlayerHealthScript.currentHealth;
        def = PlayerHealthScript.defense;
        dmg = PlayerHealthScript.damage;

        // get text components and change them
        textBox1.GetComponent<UnityEngine.UI.Text>().text = "Health : " + health.ToString() + " / 100";
        textBox2.GetComponent<UnityEngine.UI.Text>().text = "Damage : " + dmg.ToString();
        textBox3.GetComponent<UnityEngine.UI.Text>().text = "Defense : " + def.ToString();

        // if press C
        if (Input.GetKeyDown(KeyCode.C))
        {
            // always sets to opposite (true or false)
            optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
        }
        
    }
}
