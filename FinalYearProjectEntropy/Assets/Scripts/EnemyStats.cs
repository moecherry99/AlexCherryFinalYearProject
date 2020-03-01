using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public PlayerHealthScript playerhealth;
    public HealthBarScr health;

    public GameObject enemy;

    // don't need to be public if not assigning game objects in editor
    GameObject object1;
    GameObject objectFinal;
    GameObject enemyLarge;
    GameObject finalMonster;

    // variables
    public int maxHealth = 50;
    public int currentHealth;

    // this will be changed by items in the game in future
    public int defense;
    public int damage;

    // current health is max health (don't want to spawn with lower than max health)
    void Start()
    {

        object1 = GameObject.FindWithTag("RockOb1");
        enemyLarge = GameObject.FindWithTag("BossSkel1");
        objectFinal = GameObject.FindWithTag("RockFinal");
        finalMonster = GameObject.FindWithTag("FinalMonster");
        currentHealth = maxHealth;

    }
    
    void Update()
    {
        if (currentHealth <= 0)
        {
            // die if 0 health
            Die();
        }

        // developer tool, will be removed
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(20);
        }

    }

    // damage is taken from current health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage / defense;
        Debug.Log("Damage Dealt = " + damage);

        // can play hit animation/flash red

    }

    // enemy die
    void Die()
    {

        // tester
        Debug.Log("Enemy Died");

        // destroy object when it has died
        Destroy(enemy.gameObject);
        
        // finds obstacle 1 and destroys if boss 1 is killed
        if(gameObject.tag == "BossSkel1")
        {
            Destroy(object1.gameObject);
                
        }

        // open gate if last boss dies
        if (gameObject.tag == "FinalMonster")
        {
            Destroy(objectFinal.gameObject);

        }


    }

    // Test function for healing player when small mob is killed
    void Heal()
    {
        if (gameObject.tag == "SmallMonster")
        {
            PlayerHealthScript.currentHealth += 10;


        }
    }


}
