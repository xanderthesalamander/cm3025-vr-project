using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int resources = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
