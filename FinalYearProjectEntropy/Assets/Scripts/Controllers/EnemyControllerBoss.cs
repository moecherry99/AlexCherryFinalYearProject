using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Script for enemy AI look radius (to chase player if in range)
// References : https://www.youtube.com/watch?v=xppompv1DBg
// https://answers.unity.com/questions/1611499/how-do-i-make-an-enemy-deal-damage-after-5-seconds.html - damage over time if in radius
public class EnemyControllerBoss : MonoBehaviour
{
    public PlayerHealthScript health;
    public GameObject player;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // radius
    public float lookRadius = 10f;
    public float damageRadius = 1f;
    public float damageDelay = 0.8f;
    private float damageTimer = 0f;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                // attack/face target
                FaceTarget();

            }

            float attackDistance = 0.1f;

            // some form of combat, not optimal yet
            if (attackDistance <= distance)
            {
                damageTimer += Time.deltaTime;
                if (damageTimer > damageDelay)
                {
                    damageTimer -= damageDelay;
                    PlayerHealthScript player = target.GetComponent<PlayerHealthScript>();
                    if (player != null)
                        player.TakeDamage(120);
                    Debug.Log("Player took");
                }

            }
            else
            {
                damageTimer = 0;
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
    }

    private void OnDrawGizmosSelected()
    {
        // allows us to visually see when the enemy has targetted the player
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
