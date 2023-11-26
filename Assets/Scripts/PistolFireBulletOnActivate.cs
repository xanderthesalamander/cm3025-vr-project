using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PistolFireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float fireSpeed = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        // FireBullet is the function that gets called
        grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs arg) {
        // Create bullet
        GameObject spawnedBullet = Instantiate(bullet);
        // Place it in bulletSpawnPoint
        spawnedBullet.transform.position = bulletSpawnPoint.position;
        // Give it initial velocity
        spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * fireSpeed;
        // Destroy the bullet after 5 seconds
        Destroy(spawnedBullet, 5);
    }
}
