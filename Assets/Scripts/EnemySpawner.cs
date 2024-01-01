using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyA;
    public float baseProbabilityThreshold = 0.999f;
    public float minActiveTurretsToActivate = 0;
    public float additionalTurretProbIncrease = 0.00002f;
    private GameObject gameManager;
    private ResourceManager resourceManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        resourceManager = gameManager.GetComponent<ResourceManager>();
    }
    void Update()
    {
        int currentActiveTurrets = resourceManager.GetCurrentActiveTurrets();
        // If enough turrets active
        if (currentActiveTurrets >= minActiveTurretsToActivate)
        {
            // Randomly spawn enemies
            float probabilityThreshold = baseProbabilityThreshold - currentActiveTurrets * additionalTurretProbIncrease;
            if (Random.Range(0.0f,1.0f) > probabilityThreshold)
            {
                spawnEnemy(enemyA);
            }
        }
    }

    public void spawnEnemy(GameObject enemy) {
        // Create enemy
        GameObject spawnedEnemy = Instantiate(enemy);
        // Place it in current position
        spawnedEnemy.transform.position = transform.position;
    }
}
