using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent navMeshAgent;
    public float attackDistance = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set target as the player
        target = GameObject.FindWithTag("Player").transform;
        // Get enemy navigation mesh agent
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set Y position
        transform.
        // Look at target
        transform.LookAt(target);
        // Vector3 destination = 
        // destination.y = 3;
        navMeshAgent.SetDestination(target.transform.position);
        // When at a certain distance
        if (Vector3.Distance(transform.position, target.position) < attackDistance)
        {
            // Stop moving
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
        }
    }
}