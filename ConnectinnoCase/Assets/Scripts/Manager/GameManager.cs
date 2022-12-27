using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [Header("Game Stats")]
    public  float timeRemaining = 60.0f;
    
    [Header("Manager")] public UIManager uIManager;
    public PoolManager poolManager;
    public LevelManager levelManager;
    public LevelData levelData;
    public SpawnManager spawnManager;
    public JsonController jsonController;

    [Header("Transforms")] public Transform pan;

    [Header("Booleans")]
    public bool isStart;
    public bool isFinish;
    public bool isFail;
    public bool isNewLevel;

    private void Awake()
    {
        Instance = this;
        jsonController.LoadData();
    }

    private void Start()
    {
        CheckSceneRestart();
    }

    #region GameState

    public void GameStart()
    {
        jsonController.gameData.isNextLevel = true;
        jsonController.SaveData();
        SceneManager.LoadScene(0);

    }


    public void Win()
    {
        
        jsonController.gameData.levelCount++;
        if (jsonController.gameData.chestOpenCount < 3)
        {
            jsonController.gameData.chestOpenCount++;
        }
        jsonController.gameData.isNextLevel = true;
        jsonController.SaveData();
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        uIManager.homePanel.SetActive(true);
        uIManager.inGamePanel.SetActive(false);
        jsonController.gameData.levelCount++;
        
        if (jsonController.gameData.chestOpenCount < 3)
        {
            jsonController.gameData.chestOpenCount++;
        }
        jsonController.gameData.isNextLevel = true;

    }

    public void Lose()
    {
    }

    public void CheckSceneRestart()
    {
        if (jsonController.gameData.isNextLevel)
        {
            jsonController.gameData.isNextLevel = false;
            isStart = true;
            uIManager.homePanel.SetActive(false);
            jsonController.SaveData();
            spawnManager.SpawnAll();
            
        }
    }

    #endregion
  
}