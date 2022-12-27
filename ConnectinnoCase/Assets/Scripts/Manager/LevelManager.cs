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


    
    public void LevelControl(FruitType type)
    {
        for (int i = 0; i < fruitCounts.Count; i++)
        {
            if (fruitCounts[i].fruitType == type)
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
            GameManager.Instance.jsonController.SaveData();
            GameManager.Instance.uIManager.WinUI();
        }
    }

   


}