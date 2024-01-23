using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPDebugScreen : MonoBehaviour
{
    public TextMeshProUGUI TMPTextStatus;
    public TextMeshProUGUI TMPTextErrors;
    private ResourceManager resourceManager;
    private GameManager gameManager;
    private WaveManager waveManager;

    void Start()
    {
        resourceManager = GameObject.Find("Resource Manager").GetComponent<ResourceManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        waveManager = GameObject.Find("Wave Manager").GetComponent<WaveManager>();
        // Subscribe to the log event
        Application.logMessageReceived += HandleLog;
    }

    void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void Update()
    {
        string statusText = "GameState: " + gameManager.state.ToString() +
                            "\nResources: " + resourceManager.GetCurrentResources().ToString() +
                            "\nWave #: " + waveManager.getWaveLevel().ToString() +
                            "\nWave active: " + waveManager.isWaveActive().ToString();
        TMPTextStatus.text = statusText;
    }

    // This is triggered whenever there is an error
    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception)
        {
            // Extract script and line number information from the stack trace
            string[] lines = stackTrace.Split('\n');
            if (lines.Length > 0)
            {
                // The first line usually contains the error message; the second line contains script and line number
                string errorInfo = lines[1].Trim();
                
                // Append the error information to your errorsText
                string errorsText = TMPTextErrors.text + "\n" + errorInfo + ": " + logString;
                TMPTextErrors.text = errorsText;
            }
        }
    }
}