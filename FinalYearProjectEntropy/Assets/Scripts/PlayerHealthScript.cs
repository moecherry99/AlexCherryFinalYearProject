using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle players Health
// References : https://www.youtube.com/watch?v=BLfNP4Sc_iA, https://www.youtube.com/watch?v=e8GmfoaOB4Y&t=132s
public class PlayerHealthScript : MonoBehaviour
{
    
    public GameObject player;
    public GameObject respawn;

    // variables
    public int maxHealth = 100;
    public static int currentHealth;

    // this will be changed by items in the game in future
    public static int defense = 2;
    public static int damage = 5;

    public HealthBarScr healthBar;
    public EnemyStats enemyHeal;

    // current health is max health (don't want to spawn with lower than max health)
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
        
    }

    // if press Tab, take damage (developer tool)
    public void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
            // Reference for respawn : https://docs.unity3d.com/ScriptReference/GameObject.FindWithTag.html
            player = GameObject.FindWithTag("Player");
            respawn = GameObject.FindWithTag("Respawn");
            Instantiate(player, respawn.transform.position, respawn.transform.rotation);
            
            currentHealth = 100;
            healthBar.SetHealth(currentHealth);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TakeDamage(20);
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
        Application.LoadLevel(Application.loadedLevel);

    }
}
