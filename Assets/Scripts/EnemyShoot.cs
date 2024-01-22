using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject leftArm;
    public GameObject rightArm;
    public float minShootingDistance = 8.0f;
    private Transform target;
    private EnemyGun leftGunScript;
    private EnemyGun rightGunScript;

    void Start()
    {
        // Get target base
        target = GameObject.FindWithTag("PlayerBase").transform;

        // Check if leftArm and rightArm are not null before accessing components
        if (leftArm != null)
        {
            leftGunScript = leftArm.GetComponent<EnemyGun>();
            // Start shooting coroutine for the left arm
            StartCoroutine(ShootRandomly(leftGunScript, leftArm, 1f, 2f));
        }

        if (rightArm != null)
        {
            rightGunScript = rightArm.GetComponent<EnemyGun>();
            // Start shooting coroutine for the right arm
            StartCoroutine(ShootRandomly(rightGunScript, rightArm, 1f, 2f));
        }
    }

    // Coroutine to shoot at random intervals
    private IEnumerator ShootRandomly(EnemyGun gunScript, GameObject armObject, float minInterval, float maxInterval)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));

            // Check if gunScript and target are not null before shooting
            if (gunScript != null && target != null)
            {
                bool closeEnough = (Vector3.Distance(armObject.transform.position, target.position) <= minShootingDistance);

                // Check if armObject is not null before accessing its position
                if (armObject != null && closeEnough)
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
}
