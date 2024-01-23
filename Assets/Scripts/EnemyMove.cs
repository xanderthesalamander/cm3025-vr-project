using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float attackDistance = 2.0f;
    private Transform target;
    private NavMeshAgent navMeshAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        // Find the player base and set it as the target
        GameObject playerBase = GameObject.FindWithTag("PlayerBase");
        if (playerBase != null)
        {
            target = playerBase.transform;
        }
        // Get enemy navigation mesh agent
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the target is not null before proceeding
        if (target != null)
        {
            // Look at target
            transform.LookAt(target);
            // Move towards the target
            navMeshAgent.SetDestination(target.transform.position);
            // Set speed
            navMeshAgent.speed = moveSpeed;
            // When at a certain distance
            if (Vector3.Distance(transform.position, target.position) < attackDistance)
            {
                // Stop moving
                gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            }
        }
    }
}
