using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookAtPlayer : MonoBehaviour
{
    private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set target as the player
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Look at target
        transform.LookAt(target);
    }
}
