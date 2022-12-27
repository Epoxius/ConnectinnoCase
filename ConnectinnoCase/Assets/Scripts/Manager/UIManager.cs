using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Home Panel")] 
    public GameObject homePanel;

    [Header("In Game Panel")]
    public List<Sprite> fruitSprites;
    public FruitSpriteController fruitSpriteObj;
    public RectTransform fruitTable;
    public TextMeshProUGUI gameLevelText;
    public GameObject inGamePanel;
    public GameObject winPanel;
    public GameObject losePanel; 
    
    public TextMeshProUGUI timerText;
    


    private LevelManager levelManager;


    private void Start()
    {
        levelManager = GameManager.Instance.levelManager;
        FruitTableControl();
    }

    private void Update()
    {
        
            CountDownControl();
        
       
    }

    public void FruitTableControl()
    {
        gameLevelText.text = "Level " + (GameManager.Instance.jsonController.gameData.levelCount + 1);


        var levelData = GameManager.Instance.levelData;
        var levelCount = GameManager.Instance.jsonController.gameData.levelCount;


        for (int a = 0; a < fruitSprites.Count; a++)
        {
            for (int i = 0; i < levelData.levelData[levelCount].WaveDatas.Count; i++)
            {
                if (fruitSprites[a].name == levelData.levelData[levelCount].WaveDatas[i].fruitName.ToString())
                {
                    FruitSpriteController fruitSprite = Instantiate(fruitSpriteObj, fruitTable);

                    fruitSprite.SetData(fruitSprites[a], levelData.levelData[levelCount].WaveDatas[i].correctItemCount,
                        levelData.levelData[levelCount].WaveDatas[i].fruitName);
                    levelManager.fruitCounts.Add(fruitSprite);
                }
            }
        }
    }


    public void WinUI()
    {
        inGamePanel.SetActive(false);
        winPanel.SetActive(true);
    }

    public void CountDownControl()
    {
        var gm = GameManager.Instance;
        if (gm.isStart && !gm.isFail)
        {
            gm.timeRemaining -= Time.deltaTime;
            timerText.text = Mathf.Floor(gm.timeRemaining).ToString();
        }
        if (gm.timeRemaining <= 0 )
        {
            gm.isFail = true;
        }
    }
}