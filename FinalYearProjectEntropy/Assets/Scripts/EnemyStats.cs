using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public GameObject enemy;


    // variables
    public int maxHealth = 50;
    public int currentHealth;

    // this will be changed by items in the game in future
    public int defense;
    public int damage;

    // current health is max health (don't want to spawn with lower than max health)
    void Start()
    {
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

        // can play hit animation/flash red

    }

    // enemy die
    void Die()
    {

        // tester
        Debug.Log("Enemy Died");

        // destroy object when it has died
        Destroy(enemy.gameObject);

    }
}
