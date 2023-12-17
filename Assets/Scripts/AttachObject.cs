using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttachObject : MonoBehaviour
{
    public void Attach(GameObject childObject)
    {
        // Set childObject as a child of current object
        childObject.transform.SetParent(transform, true);
    }
}
