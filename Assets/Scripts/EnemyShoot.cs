using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject leftArm;
    public GameObject rightArm;
    private Transform target;
    private EnemyGun leftGunScript;
    private EnemyGun rightGunScript;

    void Start()
    {
        // Get target base
        target = GameObject.FindWithTag("PlayerBase").transform;
        // Get gun scripts
        leftGunScript = leftArm.GetComponent<EnemyGun>();
        rightGunScript = rightArm.GetComponent<EnemyGun>();
        // Start shooting coroutine for each arm
        StartCoroutine(ShootRandomly(leftGunScript, leftArm, 1f, 2f));
        StartCoroutine(ShootRandomly(rightGunScript, rightArm, 1f, 2f));
    }

    // Coroutine to shoot at random intervals
    private IEnumerator ShootRandomly(EnemyGun gunScript, GameObject armObject, float minInterval, float maxInterval)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
            if (gunScript != null)
            {
                // Target aim
                Vector3 directionToTarget = target.position - armObject.transform.position;
                // Point at the target
                armObject.transform.rotation = Quaternion.LookRotation(directionToTarget);
                // Shoot bullet
                gunScript.FireBullet();
            }
        }
    }
}

