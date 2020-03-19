using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public PlayerHealthScript playerhealth;
    public HealthBarScr healthBar;
    PlayerExperience exp;

    public GameObject enemy;

    // don't need to be public if not assigning game objects in editor

    // rock obstacles
    GameObject object1;
    GameObject object2;
    GameObject objectFinal;

    // enemy obstacle triggers
    GameObject enemyLarge;
    GameObject enemyLarge2;
    GameObject finalMonster;

    GameObject chest;

    // variables
    public int maxHealth = 50;
    public int currentHealth;

    // this will be changed by items in the game in future
    public int defense;
    public int damage;

    public static bool isDestroyed = false;

    // current health is max health (don't want to spawn with lower than max health)
    void Start()
    {

        // find rock objects
        object1 = GameObject.FindWithTag("RockOb1");
        object2 = GameObject.FindWithTag("RockOb2");
        objectFinal = GameObject.FindWithTag("RockFinal");

        // find enemy objects
        enemyLarge = GameObject.FindWithTag("BossSkel1");
        enemyLarge2 = GameObject.FindWithTag("BossSkel2");     
        finalMonster = GameObject.FindWithTag("FinalMonster");

        chest = GameObject.FindWithTag("Chest");

        // current health = max health to ensure player spawns with correct health
        currentHealth = maxHealth;

    }
    
    void Update()
    {
        if (currentHealth <= 0)
        {
            // die if 0 health
            Die();
            
        }


        isDestroyed = false;


    }

    // damage is taken from current health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage / defense;
        Debug.Log("Damage Dealt = " + damage);

        // can play hit animation/flash red

    }

    // enemy die
    public void Die()
    {
        // adds potion to player inventory on kill (loot)
        PlayerHealthScript.potionCount++;

        // exp added per kill
        PlayerExperience.exp += 30; 

        // tester
        Debug.Log("Enemy Died");

        // destroy object when it has died
        Destroy(enemy.gameObject);
        
        // finds obstacle 1 and destroys if boss 1 is killed
        if(gameObject.tag == "BossSkel1")
        {
            Destroy(object1.gameObject);                   
        }

        // finds obstacle 2 and destroys if boss 2 is killed
        if (gameObject.tag == "BossSkel2")
        {
            Destroy(object2.gameObject);
        }

        // open gate if last boss dies
        if (gameObject.tag == "FinalMonster")
        {
            Destroy(objectFinal.gameObject);
        }

        // chest interaction(s)
        if(gameObject.tag == "Chest")
        {
            PlayerHealthScript.potionCount += 4;
            PlayerExperience.exp -= 30;
            Debug.Log("Chest Opened!");
        }

        if(gameObject.tag == "SmallMonster")
        {
            PlayerExperience.exp -= 10;
        }

        if (gameObject.tag == "EnemyOpen")
        {
            PlayerExperience.exp -= 20;
        }

        isDestroyed = true;

    }
    
}
