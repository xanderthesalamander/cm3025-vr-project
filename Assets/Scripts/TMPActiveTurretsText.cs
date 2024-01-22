using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPActiveTurretsText : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText;
    private ResourceManager resourceManager;

    void Start()
    {
        resourceManager = GameObject.Find("Resource Manager").GetComponent<ResourceManager>();
    }

    void Update()
    {
        textMeshProText.text = resourceManager.GetCurrentActiveTurrets().ToString();
    }
}
