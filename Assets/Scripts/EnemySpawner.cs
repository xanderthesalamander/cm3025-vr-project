using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyA;
    public float probabilityThreshold = 0.999f;

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0.0f,1.0f) > probabilityThreshold)
        {
            spawnEnemy(enemyA);
        }
    }

    public void spawnEnemy(GameObject enemy) {
        // Create enemy
        GameObject spawnedEnemy = Instantiate(enemy);
        // Place it in current position
        spawnedEnemy.transform.position = transform.position;
    }
}
