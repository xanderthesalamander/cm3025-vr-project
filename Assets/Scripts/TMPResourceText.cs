using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPResourceText : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText;
    private GameObject gameManager;
    private ResourceManager resourceManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        resourceManager = gameManager.GetComponent<ResourceManager>();
    }

    void Update()
    {
        textMeshProText.text = resourceManager.resources.ToString();
    }
}
