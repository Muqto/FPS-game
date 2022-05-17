using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking 

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    private ShootAI shootAI;

private void Awake(){
    player = GameObject.Find("Player").transform;
    agent = GetComponent<NavMeshAgent>();
    shootAI = GetComponent<ShootAI>();
}
    // Update is called once per frame
    void Update()
    {
        //Check for sight or attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        
        if(!playerInAttackRange && !playerInSightRange) patrol();
        if(playerInAttackRange && playerInSightRange) attack();
        if(playerInSightRange && !playerInAttackRange) follow();
    }
    public void patrol(){
        if(!walkPointSet) SearchWalkPoint();
        if (walkPointSet){
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if(distanceToWalkPoint.magnitude < 1f){
            walkPointSet = false;
        }
    }
    public void SearchWalkPoint(){
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y , transform.position.z + randomZ);
        if(Physics.Raycast(walkPoint, -transform.up, 2f)){
            walkPointSet = true;
        }
    }
    public void follow(){
        agent.SetDestination(player.position);
    }
    public void attack(){
        // stop moving
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked){
            //attack code insert here
            shootAI.shoot();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack(){
        alreadyAttacked = false;
    }
}
