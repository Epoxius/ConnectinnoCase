using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [Header("Level Stats")]
    public int _levelCount;

    public List<FruitSpriteController> fruitCounts;


    
    public void LevelControl(FruitType type,bool isDone)
    {
        for (int i = 0; i < fruitCounts.Count; i++)
        {
            if (fruitCounts[i].fruitType == type && !isDone)
            {
                fruitCounts[i].FruitControl();
            }
        }

        int finishCountControl = 0;
        for (int i = 0; i < fruitCounts.Count; i++)
        {
            if (fruitCounts[i].FruitFinishControl())
            {
                finishCountControl++;
            }
        }

        if (finishCountControl >= fruitCounts.Count)
        {
          
           
            SaveChestProgress();
            GameManager.Instance.jsonController.SaveData();
            GameManager.Instance.uIManager.WinUI();
        }
    }

    public void SaveChestProgress()
    {
        var gm = GameManager.Instance;
        gm.uIManager.rewardChest.SetParent(gm.uIManager.winPanel.transform);
       
        if (gm.jsonController.gameData.chestOpenCount < 3)
        {
            gm.jsonController.gameData.chestOpenCount++;
            gm.chestController.chestImage.fillAmount  += .3f;
            gm.jsonController.gameData.chestFill += gm.chestController.chestImage.fillAmount;
        }
    }
   


}