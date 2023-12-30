using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public GameObject bodyAttachPoint;
    public Transform referenceObject; // Reference object to rotate
    private bool isAssembled = false;

    private AttachedObjectRef checkBody;

    public void Start()
    {
        checkBody = bodyAttachPoint.GetComponent<AttachedObjectRef>();
    }

    private void Update()
    {
        // Check if turret is assembled
        isAssembled = CheckAssembled();
        // When assembled
        if (isAssembled)
        {
            RotateReferenceObject();
        }
    }

    // Checks if turret is assembled
    public bool CheckAssembled()
    {
        // Check if the AttachedObjectRef script is attached
        if (checkBody != null)
        {
            // Check for the turretBody
            GameObject turretBody = checkBody.attachedObject;
            if (turretBody != null)
            {   
                // Check for left and right arm attach point scripts
                GameObject armAttachPointL = turretBody.transform.Find("Arm attach point L")?.gameObject;
                AttachedObjectRef checkArmL = armAttachPointL.GetComponent<AttachedObjectRef>();
                GameObject armAttachPointR = turretBody.transform.Find("Arm attach point R")?.gameObject;
                AttachedObjectRef checkArmR = armAttachPointR.GetComponent<AttachedObjectRef>();
                // Check for left and right arms
                if (checkArmL != null && checkArmR != null)
                {
                    GameObject turretArmL = checkArmL.attachedObject;
                    GameObject turretArmR = checkArmR.attachedObject;
                    // If both left and right arms are found
                    if (turretArmL != null && turretArmR != null)
                    {
                        // Turret assembled (both body and arms attached)
                        return true;
                    }
                }
            }
        }
        // Turret is not fully assembled
        return false;
    }

    private void RotateReferenceObject()
    {
        // Rotate the reference object on the y-axis (adjust the speed as needed)
        referenceObject.Rotate(Vector3.up * Time.deltaTime * 30.0f); // Adjust the rotation speed as needed
    }
}
