using UnityEngine;
using UnityEngine.UI;

public class ObjectHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public int resourceValue = 10;
    public AudioClip deadSound;
    private ResourceManager resourceManager;
    private GameManager gameManager;
    private WaveManager waveManager;
    public GameObject healthBarUI;
    public Slider slider;

    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        resourceManager = GameObject.Find("Resource Manager").GetComponent<ResourceManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        waveManager = GameObject.Find("Wave Manager").GetComponent<WaveManager>();
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
            // Play dead sound at current position
            PlayDeadSound();
            // Add resource
            resourceManager.AddResource(resourceValue);
            // Game over if this is the base
            if (gameObject.CompareTag("PlayerBase"))
            {
                waveManager.stopAndResetWave();
                gameManager.UpdateGameState(GameState.LoseState);
            }
            // Destroy the GameObject
            Destroy(gameObject);
        }
        // For healing
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    void PlayDeadSound()
    {
        // Create new GameObject to handle the sound
        // This is in order to get rid of the object while still playing the sound
        GameObject audioObject = new GameObject("DeadSoundObject");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(deadSound);
        // Destroy audio source when sound finished
        Destroy(audioObject, deadSound.length);
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
