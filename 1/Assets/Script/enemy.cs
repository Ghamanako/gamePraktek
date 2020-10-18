using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WhatisGround, WhatisPlayer;
    public float health;
    //Patroling
    public Vector3 WalkPoint;
    bool walkPointSet;
    public float WalkPointRange;

    // Attacking
    public float TimeBetweenAttacks;
    bool AlreadyAttacked;
    public GameObject Projectile;

    //States
    public float sightRange, AttackRange;
    public bool PlayerInsightRange, PlayerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("character").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //check for sight and attack range
        PlayerInsightRange = Physics.CheckSphere(transform.position, sightRange, WhatisPlayer);
        PlayerInAttackRange= Physics.CheckSphere(transform.position, sightRange, WhatisPlayer);

        if (!PlayerInsightRange && !PlayerInAttackRange) Patroling();
        if (PlayerInsightRange && PlayerInAttackRange) ChasePlayer();
        if (PlayerInAttackRange && PlayerInsightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(WalkPoint);
        Vector3 DistanceToWalkPoint = transform.position - WalkPoint;

        //Walk point reached
        if (DistanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-WalkPointRange, WalkPointRange);
        float randomX = Random.Range(-WalkPointRange, WalkPointRange);

        WalkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(WalkPoint, -transform.up, 2f, WhatisGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!AlreadyAttacked)
        {
            //attack code here
            Rigidbody rb = Instantiate(Projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);


            AlreadyAttacked = true;
            Invoke(nameof(ResetAttack), TimeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        AlreadyAttacked = false;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Invoke(nameof(DestroyEnemy), .5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
