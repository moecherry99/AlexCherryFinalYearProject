using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script to handle players Health
// References : https://www.youtube.com/watch?v=BLfNP4Sc_iA, https://www.youtube.com/watch?v=e8GmfoaOB4Y&t=132s
// https://answers.unity.com/questions/177137/regenerating-health-script.html - health regeneration
// https://forum.unity.com/threads/using-my-potion-c.412307/ - potion functionality for inventory system
// https://answers.unity.com/questions/286068/do-something-only-once.html - do something only once (for quest rewards)

public class PlayerHealthScript : MonoBehaviour
{
    
    public GameObject player;
    public GameObject respawn;
    public GameObject respawn2;
    public GameObject respawn3;
    public GameObject weapon;
    public GameObject cam;
    public GameObject cdTimer;
    public GameObject dialogBox;
    public GameObject objectiveText;
    public GameObject rescueText;
    public GameObject respawnNpc;
    public GameObject npc2;
    public GameObject respawnOpen;

    // variables
    public static float timerSkill;
    public static int potionCount = 1;
    public static float maxHealth = 250f;
    public static float currentHealth;
    public float regeneration = 1f;
    public float attackRatePower = 1f;
    float nextAttackTime = 0f;
    bool activateOnce;
    bool activateOnce2;
    bool activateOnce3;

    // this will be changed by items in the game in future
    public static int defense = 2;
    public static int damage = 5;
    int deathCount = 0;

    public HealthBarScr healthBar;
    NPCScript npc;

    // current health is max health (don't want to spawn with lower than max health)
    public void Start()
    {
        activateOnce = false;
        activateOnce2 = true;
        activateOnce3 = true;
        cam = GameObject.FindWithTag("MainCamera");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        // SoundManagerScript.PlaySound("Cave1");
        

    }

    // if press Tab, take damage (developer tool)
    public void Update()
    {

        // These 4 functions are not optimal. They can be used at any time, leading to cheats, but boolean variables only allow for one usage per playthrough
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (activateOnce == true)
        {
            // teleport to mission
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                objectiveText.GetComponent<UnityEngine.UI.Text>().text = "Current Objective : Rescue the hostage! (Enter to return after death)";               
                Move2();
                activateOnce = false;
            }
        }

        if (activateOnce2 == true)
        {
            // return to town
            if (Input.GetKeyDown(KeyCode.Y))
            {
                dialogBox.GetComponent<UnityEngine.UI.Text>().text = "Thank you for rescuing him! Here is your reward (Press Shift to accept reward)";
                objectiveText.GetComponent<UnityEngine.UI.Text>().text = "Current Objective : Return To Toland for rewards.";
                rescueText.GetComponent<UnityEngine.UI.Text>().text = "Thank you for saving me!";
                Move();
                activateOnce2 = false;
                npc2.transform.position = respawnNpc.transform.position;
                npc2.transform.rotation = respawnNpc.transform.rotation;             

            }
        }

        if (activateOnce3 == true)
        {
            // accept rewards
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                objectiveText.GetComponent<UnityEngine.UI.Text>().text = "";
                PlayerExperience.exp += 100;
                potionCount += 5;
                dialogBox.GetComponent<UnityEngine.UI.Text>().text = "Thank you for rescuing him!";
                activateOnce3 = false;
            }
        }

        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // health regeneration
        if (currentHealth <= maxHealth)
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
            respawn3 = GameObject.FindWithTag("Respawn3");
            respawn2 = GameObject.FindWithTag("Respawn2");
            weapon = GameObject.FindWithTag("Weapon");
            
            //Instantiate(player, respawn.transform.position, respawn.transform.rotation);

            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
            Die();
        }

        // developer tool to add experience, will take out after development
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerExperience.exp += 1000;
        }

        // developer tool, will take out after development
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TakeDamage(200);
        }

        // developer tool to heal and test level, will take out after development
        if (Input.GetKeyDown(KeyCode.Alpha1))
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
            cdTimer.GetComponent<UnityEngine.UI.Text>().text = "Skill : Ready (R)";
            // for drain attack
            if (Input.GetKeyDown(KeyCode.R))
            {
                currentHealth += 25;
                healthBar.SetHealth(currentHealth);
                nextAttackTime = Time.time + 12f / attackRatePower;
                cdTimer.GetComponent<UnityEngine.UI.Text>().text = "Skill : Not Ready";
                if (currentHealth >= maxHealth)
                {
                    
                    currentHealth = maxHealth;
                    nextAttackTime = Time.time + 12f / attackRatePower;
                    
                }
            }
        }

        // potion count       
        if (Input.GetKeyDown(KeyCode.E))
        {
            // if more than 1 potion, call UsePotion
            if (potionCount > 0)
            {
                UsePotion();
                SoundManagerScript.PlaySound("Potion");
            }

            // if 0 potions or max health, call DontUsePotion and do nothing
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

    public void Die()
    {
        // https://answers.unity.com/questions/634219/how-do-i-respawn-the-player-after-it-dies.html
        // Not a perfect way to respawn as it resets all progress, but will be worked upon in future
        //SceneManager.LoadScene(0);

        // new proper functionality for respawning
        player.transform.position = respawn3.transform.position;
        player.transform.rotation = respawn3.transform.rotation;

        // set potion count = potion count - 1 so player loses potions on death
        if (potionCount > 0)
        {
            potionCount = potionCount - 1;
        }

        activateOnce = true;
        deathCount += 1;
        
    }

    public void Move()
    {
        player.transform.position = respawn2.transform.position;
        player.transform.rotation = respawn2.transform.rotation;
    }

    public void Move2()
    {
        player.transform.position = respawn.transform.position;
        player.transform.rotation = respawn.transform.rotation;
    }

    public void Move3()
    {
        player.transform.position = respawn3.transform.position;
        player.transform.rotation = respawn3.transform.rotation;
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
