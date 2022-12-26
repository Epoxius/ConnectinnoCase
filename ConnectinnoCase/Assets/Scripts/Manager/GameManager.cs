using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static  GameManager Instance { get; set; }

    [Header("Manager")] 
    public UIManager uIManager;
    public PoolManager poolManager;
    public LevelManager levelManager;
    public LevelData levelData;
    public SpawnManager spawnManager;

    [Header("Transforms")] 
    public Transform pan;

    [Header("Booleans")]
    public bool isStart;
    private void Awake()
    {
        Instance = this;
    }

    public void GameStart()
    {
        isStart = true;
        uIManager.homePanel.SetActive(false);
        spawnManager.SpawnAll();
    }
}
