using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public int resourceValue = 10;
    private GameObject gameManager;
    private ResourceManager resourceManager;

    public GameObject healthBarUI;
    public Slider slider;

    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        gameManager = GameObject.FindWithTag("GameManager");
        resourceManager = gameManager.GetComponent<ResourceManager>();
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

    // Returns health as a float between 0 and 1
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
            resourceManager.AddResource(resourceValue);
            Destroy(gameObject);
        }
    }

    // Heal
    public void heal(float healthValue)
    {
        health += healthValue;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
