using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    public EnemyHealth enemy;
    public float damage_multiplier;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // Get bullet damage
            BulletStats bulletStats = collision.gameObject.GetComponent<BulletStats>();
            float bullet_damage = bulletStats.damage;
            // Calculate damage
            float damage = damage_multiplier * bullet_damage;
            // Take damage
            enemy.takeDamage(damage);
            // Delete bullet
            Destroy(collision.gameObject);
        }
    }
}
