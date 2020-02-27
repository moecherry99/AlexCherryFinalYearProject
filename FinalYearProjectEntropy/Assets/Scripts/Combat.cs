using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// References : https://answers.unity.com/questions/796881/c-how-can-i-let-something-happen-after-a-small-del.html - Delay mechanic for animation
// https://www.youtube.com/watch?v=sPiVz1k-fEs - Video for attacking/damaging enemies with attacks/setting stats by Brackeys
// https://forum.unity.com/threads/rotate-gameobject-to-where-camera-is-facing.501460/ - Rotate sword around the main camera

[RequireComponent(typeof(PlayerHealthScript))]
[RequireComponent(typeof(EnemyStats))]
public class Combat : MonoBehaviour
{
    EnemyStats enemyStats;
    PlayerHealthScript myStats;

    // variables
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public float attackRange = 0.5f;

    public GameObject swordSwing;
    private GameObject MainCamera;

    void Awake()
    {
        // find our main camera for our sword swing animation
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Start()
    {
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
        
        // if press Q, do attack animation and damage if in range of enemy
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // sets sword position relative to our main camera, as to follow rotation
            swordSwing.transform.rotation = Quaternion.Euler(40, Camera.main.transform.eulerAngles.y, 0);

            // Delay for 0.1 seconds so we can reset the sword position before attacking again
            Invoke("Delay1", 0.1f);

            //swordSwing.transform.rotation = Quaternion.Euler(40, 0, 0);
            Attack();
            
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
