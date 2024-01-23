using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;
    public static event Action<GameState> OnGameStateChanged;
    // Screens
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject planningScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject victoryScreen;
    // Base target
    [SerializeField] private GameObject baseTargetPosition;
    [SerializeField] private GameObject baseTargetPrefab;
    private GameObject currentBaseTarget;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Set inactive at the beginning
        startScreen?.SetActive(false);
        planningScreen?.SetActive(false);
        gameOverScreen?.SetActive(false);
        victoryScreen?.SetActive(false);
        // Initial state
        UpdateGameState(GameState.SetupState);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.SetupState:
                startScreen?.SetActive(true);
                break;
            case GameState.TutorialState:
                break;
            case GameState.GameStart:
                ResetGame();
                startScreen?.SetActive(false);
                planningScreen?.SetActive(true);
                victoryScreen?.SetActive(false);
                gameOverScreen?.SetActive(false);
                break;
            case GameState.PlayerPlanningState:
                startScreen?.SetActive(false);
                planningScreen?.SetActive(true);
                victoryScreen?.SetActive(false);
                gameOverScreen?.SetActive(false);
                break;
            case GameState.EnemyWaveState:
                planningScreen.SetActive(false);
                break;
            case GameState.VictoryState:
                planningScreen?.SetActive(false);
                victoryScreen?.SetActive(true);
                break;
            case GameState.LoseState:
                planningScreen?.SetActive(false);
                gameOverScreen?.SetActive(true);
                break;
        }
        // Notify that the state has been updated to any subscriber
        OnGameStateChanged?.Invoke(newState);
    }

    public void startGame()
    {
        // This is a workaround to make this available in the unity interface
        UpdateGameState(GameState.GameStart);
    }

    public void startPlayerPlanningState()
    {
        // This is a workaround to make this available in the unity interface
        UpdateGameState(GameState.PlayerPlanningState);
    }

    public void startEnemyWaveState()
    {
        // This is a workaround to make this available in the unity interface
        UpdateGameState(GameState.EnemyWaveState);
    }

    private void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    private void RespawnBase()
    {
        // Destroy current base
        if (currentBaseTarget != null)
        {
            Destroy(currentBaseTarget);
        }
        // Create Base
        currentBaseTarget = Instantiate(baseTargetPrefab);
        // Place it
        currentBaseTarget.transform.position = baseTargetPosition.transform.position;
    }

    private void ResetGame()
    {
        DestroyAllEnemies();
        RespawnBase();
        // FIXME: Respawn guns
        // FIXME: Reset turrets
    }
}

public enum GameState {
    SetupState,
    TutorialState,
    GameStart,
    PlayerPlanningState,
    EnemyWaveState,
    VictoryState,
    LoseState,
}