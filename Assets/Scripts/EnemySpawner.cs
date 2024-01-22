using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyA;
    public float baseProbabilityThreshold = 0.999f;
    public float minActiveTurretsToActivate = 0;
    public float additionalTurretProbIncrease = 0.00002f;
    private ResourceManager resourceManager;
    private WaveManager waveManager;
    private AudioSource sound;

    void Start()
    {
        resourceManager = GameObject.Find("Resource Manager").GetComponent<ResourceManager>();
        waveManager = GameObject.Find("Wave Manager").GetComponent<WaveManager>();
        sound = GetComponent<AudioSource>();
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
                waveManager.AddSpawnedEnemy();
            }
        }
    }

    public void spawnEnemy(GameObject enemy) {
        // Play sound
        sound.Play();
        // Create enemy
        GameObject spawnedEnemy = Instantiate(enemy);
        // Place it in current position
        spawnedEnemy.transform.position = transform.position;
    }
}
