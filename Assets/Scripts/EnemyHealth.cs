using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    public GameObject healthBarUI;
    public Slider slider;

    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    void Update()
    {
        slider.value = CalculateHealth();
        // Activate health bar when hit
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        // Destroy when no health
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        // For healing
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    // 
    float CalculateHealth()
    {
        return health / maxHealth;
    }

    // Take damage
    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
