using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private int resources = 0;

    public int GetCurrentResources()
    {
        return resources;
    }

    public void AddResource(int value)
    {
        resources += value;
    }

    public void RemoveResource(int value)
    {
        resources -= value;
    }
}
