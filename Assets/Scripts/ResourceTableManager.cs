using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTableManager : MonoBehaviour
{
    public bool doorsOpen = false;
    public Transform turretPartSpawnPoint;
    public GameObject turretPartSelected;
    public List<GameObject> turretParts;
    public bool enoughResources;
    public AudioClip printPartAudio;
    public AudioClip errorAudio;
    private int currentPartIndex = 0;
    private Animator animator;
    private GameObject gameManager;
    private ResourceManager resourceManager;
    private int resourceCost;
    private AudioSource audioSource;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        resourceManager = gameManager.GetComponent<ResourceManager>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        turretPartSelected = turretParts[0];
        checkEnoughResourcesToSpawn();
    }

    void Update()
    {
        checkEnoughResourcesToSpawn();
    }

    private void updateDoorsAnimator()
    {
        // Update animator controller
        animator.SetBool("doorsOpen", doorsOpen);
    }

    public void switchDoors()
    {
        doorsOpen = !doorsOpen;
        updateDoorsAnimator();
    }

    public void openDoors()
    {
        doorsOpen = true;
        updateDoorsAnimator();
    }

    public void closeDoors()
    {
        doorsOpen = false;
        updateDoorsAnimator();
    }

    public void SelectNextPart()
    {
        currentPartIndex = (currentPartIndex + 1) % turretParts.Count;
        turretPartSelected = turretParts[currentPartIndex];
    }

    public void SelectPreviousPart()
    {
        currentPartIndex = (currentPartIndex - 1 + turretParts.Count) % turretParts.Count;
        turretPartSelected = turretParts[currentPartIndex];
    }

    private void checkEnoughResourcesToSpawn()
    {
        // Get cost
        TurretPartStats turretPartStats = turretPartSelected.GetComponent<TurretPartStats>();
        resourceCost = turretPartStats.resourceCost;
        // Check if enough resources
        enoughResources = (resourceManager.GetCurrentResources() >= resourceCost);
    }
    
    public void SpawnTurretPart()
    {
        if (enoughResources)
        {
            // Pay resources
            resourceManager.RemoveResource(resourceCost);
            // Spawn the turret part in the spawn point
            GameObject spawnedPart = Instantiate(turretPartSelected);
            spawnedPart.transform.position = turretPartSpawnPoint.position;
            // Play build sound
            audioSource.PlayOneShot(printPartAudio);
        }
        else
        {
            // Play error sound
            audioSource.PlayOneShot(errorAudio);
        }
    }
}
