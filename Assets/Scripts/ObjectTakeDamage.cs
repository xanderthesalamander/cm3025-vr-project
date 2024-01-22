using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTakeDamage : MonoBehaviour
{
    public ObjectHealth objectHealth;
    public float damage_multiplier;
    public string bulletTag = "Bullet";
    public AudioClip hitSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == bulletTag)
        {
            // Play sound
            audioSource.PlayOneShot(hitSound);
            // Get bullet damage
            BulletStats bulletStats = collision.gameObject.GetComponent<BulletStats>();
            float bullet_damage = bulletStats.damage;
            // Calculate damage
            float damage = damage_multiplier * bullet_damage;
            // Take damage
            objectHealth.takeDamage(damage);
            // Delete bullet
            Destroy(collision.gameObject);
        }
    }
}
