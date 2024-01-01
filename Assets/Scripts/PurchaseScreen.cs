using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchaseScreen : MonoBehaviour
{
    public GameObject resourceTable;
    public TextMeshProUGUI tmpTextName;
    public TextMeshProUGUI tmpTextCost;
    public Image turretPartPreviewImage;
    public Image errorScreenBG;
    public Color errorScreenFilter;
    public Color noErrorScreenFilter;
    public TextMeshProUGUI tmpErrorText;
    private bool enoughResources;
    private GameObject gameManager;
    private ResourceManager resourceManager;
    private ResourceTableManager resourceTableManager;
    private GameObject selectedPart;
    private TurretPartStats selectedPartStats;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        resourceManager = gameManager.GetComponent<ResourceManager>();
        resourceTableManager = resourceTable.GetComponent<ResourceTableManager>();
        selectedPart = resourceTableManager.turretPartSelected;
        selectedPartStats = selectedPart.GetComponent<TurretPartStats>();
        enoughResources = resourceTableManager.enoughResources;
    }

    void Update()
    {
        selectedPart = resourceTableManager.turretPartSelected;
        selectedPartStats = selectedPart.GetComponent<TurretPartStats>();
        enoughResources = resourceTableManager.enoughResources;
        updateScreen();
    }

    public void updateScreen()
    {
        // Update name, cost and image preview
        tmpTextName.text = selectedPartStats.partName;
        tmpTextCost.text = selectedPartStats.resourceCost.ToString();
        turretPartPreviewImage.sprite = selectedPartStats.partImageSprite;
        if (!enoughResources)
        {
            errorScreenBG.color = errorScreenFilter;
            tmpErrorText.text = "Not Enough Resources";
        }
        else
        {
            errorScreenBG.color = noErrorScreenFilter;
            tmpErrorText.text = "";
        }
    }
}
