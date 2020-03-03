using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// References : https://answers.unity.com/questions/796881/c-how-can-i-let-something-happen-after-a-small-del.html - Delay mechanic for animation
// https://www.youtube.com/watch?v=sPiVz1k-fEs - Video for attacking/damaging enemies with attacks/setting stats by Brackeys and attack delay system
// https://forum.unity.com/threads/rotate-gameobject-to-where-camera-is-facing.501460/ - Rotate sword around the main camera

[RequireComponent(typeof(PlayerHealthScript))]
[RequireComponent(typeof(EnemyStats))]
public class Combat : MonoBehaviour
{
    // script references
    EnemyStats enemyStats;
    PlayerHealthScript myStats;

    // variables
    public Transform attackPoint;
    public LayerMask enemyLayers;

    // attack variables
    public int attackDamage = 40;
    public float attackRange = 0.5f;
    public float attackRate = 0.4f;
    float nextAttackTime = 0f;
    public float distanceDamage = 1f;

    // power attack variables
    float nextAttackTimePower = 0f;
    public float attackRatePower = 1f;

    public GameObject swordSwing;

    // find game objects
    GameObject en1;
    GameObject en2;
    GameObject en3;

    private GameObject MainCamera;

    void Awake()
    {
        // find our main camera for our sword swing animation
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        // find enemy objects
        en1 = GameObject.FindGameObjectWithTag("SmallMonster");
        en2 = GameObject.FindGameObjectWithTag("MediumMonster");
        en3 = GameObject.FindGameObjectWithTag("BossSkel1");     
    }

    void Start()
    {
        
        // function to show level is cleared, destroying the object blocking the gate (only works if boss is killed)
        if (GameObject.FindGameObjectWithTag("SmallMonster") == null && GameObject.FindGameObjectWithTag("MediumMonster") == null && GameObject.FindGameObjectWithTag("BossSkel1") == null)
        {
            Debug.Log("Level Cleared");
        }

        // get weapon for animation
        swordSwing = GameObject.FindWithTag("Weapon");
        myStats = GetComponent<PlayerHealthScript>(); // stat finder for player
        enemyStats = GetComponent<EnemyStats>(); // stat finder for enemy

    }

    // get player stats
    public void Attack (PlayerHealthScript targetStats)
    {
        targetStats.TakeDamage(20);
    }

    // get enemy stats
    public void AttackEnemy(EnemyStats enemyStats1)
    {    
        enemyStats1.TakeDamage(20);
    }

    void Update()
    {
        // attack delay
        if (Time.time >= nextAttackTime)
        {

            // if press Q, do attack animation and damage if in range of enemy
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // sets sword position relative to our main camera, as to follow rotation
                swordSwing.transform.rotation = Quaternion.Euler(40, Camera.main.transform.eulerAngles.y, 0);

                // Delay for 0.1 seconds so we can reset the sword position before attacking again
                Invoke("Delay1", 0.1f);

                //swordSwing.transform.rotation = Quaternion.Euler(40, 0, 0);
                Attack();

                // Delays attack accordingly (trial and error)
                nextAttackTime = Time.time + 0.4f / attackRate;

            }
           
        }

        if (Time.time >= nextAttackTimePower)
        {
            // if press Q, do attack animation and damage if in range of enemy
            if (Input.GetKeyDown(KeyCode.R))
            {
                // sets sword position relative to our main camera, as to follow rotation
                swordSwing.transform.rotation = Quaternion.Euler(40, Camera.main.transform.eulerAngles.y, 0);

                // Delay for 0.1 seconds so we can reset the sword position before attacking again
                Invoke("Delay1", 0.1f);

                //swordSwing.transform.rotation = Quaternion.Euler(40, 0, 0);
                PowerAttack();

                // Delays attack accordingly (trial and error)
                nextAttackTimePower = Time.time + 12f / attackRatePower;

            }
        }
    }

    void Attack()
    {
        
        // animator.SetTrigger("Attack");

        // array for our enemies in enemy tag layer
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        // if several enemies are in range we can hit all at once
        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            enemy.GetComponent<EnemyStats>().TakeDamage(attackDamage / 2);
        }
             
    }

    // Method for drain attack
    void PowerAttack()
    {

        // animator.SetTrigger("Attack");

        // array for our enemies in enemy tag layer
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        // if several enemies are in range we can hit all at once
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            enemy.GetComponent<EnemyStats>().TakeDamage(attackDamage / 1);
        }

    }

    // shows in editor our attack range for easy adjustments
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        // shows the range with a sphere
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Delay1()
    {
        // Delay method changes sword back to original position after attacking
        swordSwing.transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);       
    } 

}
