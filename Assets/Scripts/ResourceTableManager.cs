using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTableManager : MonoBehaviour
{
    public bool doorsOpen = false;
    public Transform turretPartSpawnPoint;

    private Animator animator;
    private GameObject gameManager;
    private ResourceManager resourceManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        resourceManager = gameManager.GetComponent<ResourceManager>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        updateDoorsAnimator();
    }

    private void updateDoorsAnimator()
    {
        // Update animator controller
        animator.SetBool("doorsOpen", doorsOpen);
    }

    public void switchDoors()
    {
        doorsOpen = !doorsOpen;
    }

    public void openDoors()
    {
        doorsOpen = true;
    }

    public void closeDoors()
    {
        doorsOpen = false;
    }

    public void spawnTurretPart(GameObject turretPart)
    {
        // Get cost
        TurretPartStats turretPartStats = turretPart.GetComponent<TurretPartStats>();
        int recourceCost = turretPartStats.resourceCost;
        // Check if enough resources
        if (resourceManager.GetCurrentResources() >= recourceCost)
        {
            // Pay resources
            resourceManager.RemoveResource(recourceCost);
            // Spawn the turret part in the spawn point
            GameObject spawnedPart = Instantiate(turretPart);
            spawnedPart.transform.position = turretPartSpawnPoint.position;
        }
        else
        {

        }
    }
}
