using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script to handle players Health
// References : https://www.youtube.com/watch?v=BLfNP4Sc_iA, https://www.youtube.com/watch?v=e8GmfoaOB4Y&t=132s
// https://answers.unity.com/questions/177137/regenerating-health-script.html - health regeneration
// https://forum.unity.com/threads/using-my-potion-c.412307/ - potion functionality for inventory system

public class PlayerHealthScript : MonoBehaviour
{
    
    public GameObject player;
    public GameObject respawn;
    public GameObject weapon;
    public GameObject cam;

    // variables
    public static int potionCount = 1;
    public static float maxHealth = 250f;
    public static float currentHealth;
    public float regeneration = 1f;
    public float attackRatePower = 1f;
    float nextAttackTime = 0f;

    // this will be changed by items in the game in future
    public static int defense = 2;
    public static int damage = 5;

    public HealthBarScr healthBar;

    // current health is max health (don't want to spawn with lower than max health)
    public void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // if press Tab, take damage (developer tool)
    public void Update()
    {
        // health regeneration
        if(currentHealth <= maxHealth)
        {
            currentHealth += regeneration * Time.deltaTime;
            healthBar.SetHealth(currentHealth);
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
                
            }
        }

        if (currentHealth <= 0)
        {
            
            // Reference for respawn : https://docs.unity3d.com/ScriptReference/GameObject.FindWithTag.html
            player = GameObject.FindWithTag("Player");
            respawn = GameObject.FindWithTag("Respawn");
            weapon = GameObject.FindWithTag("Weapon");
            
            //Instantiate(player, respawn.transform.position, respawn.transform.rotation);

            currentHealth = 250;
            healthBar.SetHealth(currentHealth);
            Die();
        }

        // developer tool, will take out after development
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TakeDamage(80);
        }

        // developer tool to heal and test level, will take out after development
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentHealth += 20;
            healthBar.SetHealth(currentHealth);
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;

            }
        }

        if (Time.time >= nextAttackTime)
        {
            // for drain attack
            if (Input.GetKeyDown(KeyCode.R))
            {
                currentHealth += 25;
                healthBar.SetHealth(currentHealth);
                nextAttackTime = Time.time + 12f / attackRatePower;
                if (currentHealth >= maxHealth)
                {
                    
                    currentHealth = maxHealth;
                    nextAttackTime = Time.time + 12f / attackRatePower;
                    
                }
            }
        }

        // potion count       
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // if more than 1 potion, call UsePotion
            if (potionCount > 0)
            {
                UsePotion();                  
            }

            // if 0 potions, call DontUsePotion and do nothing
            if (potionCount == 0)
            {
                DontUsePotion();
            }

        }

        // developer tool for adding potions to inventory, remove after development
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            potionCount++;
        }

    }

    // damage is taken from current health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage / defense;      
        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        // https://answers.unity.com/questions/634219/how-do-i-respawn-the-player-after-it-dies.html
        // Not a perfect way to respawn as it resets all progress, but will be worked upon in future
        //SceneManager.LoadScene(0);

        // new proper functionality for respawning
        player.transform.position = respawn.transform.position;
        player.transform.rotation = respawn.transform.rotation;

        // set potion count = potion count - 1 so player loses potions on death
        if (potionCount > 0)
        {
            potionCount = potionCount - 1;
        }
    }

    // call this function if potion count is over 1
    public void UsePotion()
    {
        if (potionCount >= 1)
        {           
            currentHealth += 20;
            healthBar.SetHealth(currentHealth);
            potionCount--;
        }

        // if potion count is 0, don't allow it to drop below 0 as negative potions 
        // means picking up potions doesn't award the player with any
        if (potionCount <= 0)
        {
            potionCount = 0;

        }
        
        // set health
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;

        }

    }

    // call this function if player doesn't have potions
    public void DontUsePotion()
    {
        return;
    }
  
}
