using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] List<GameObject> guns;
    public float minShootingDistance = 8.0f;
    private Transform target;

    void Start()
    {
        // Get target base
        target = GameObject.FindWithTag("PlayerBase").transform;

        // Start shooting coroutine for each gun in the list
        foreach (GameObject gunObject in guns)
        {
            EnemyGun gunScript = gunObject.GetComponent<EnemyGun>();
            StartCoroutine(ShootRandomly(gunScript, gunObject, 1f, 2f));
        }
    }

    // Coroutine to shoot at random intervals
    private IEnumerator ShootRandomly(EnemyGun gunScript, GameObject gunObject, float minInterval, float maxInterval)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));

            // Check if gunScript and target are not null before shooting
            if (gunScript != null && target != null)
            {
                bool closeEnough = (Vector3.Distance(gunObject.transform.position, target.position) <= minShootingDistance);

                // Check if gunObject is not null before accessing its position
                if (gunObject != null && closeEnough)
                {
                    // Target aim
                    Vector3 directionToTarget = target.position - gunObject.transform.position;
                    // Point at the target
                    gunObject.transform.rotation = Quaternion.LookRotation(directionToTarget);
                    // Shoot bullet
                    gunScript.FireBullet();
                }
            }
        }
    }
}
