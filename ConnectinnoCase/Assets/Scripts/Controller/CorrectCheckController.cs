using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CorrectCheckController : MonoBehaviour
{
    public bool isCorrect;
    public void Check(FruitType type)
    {
        var fruit = GameManager.Instance.levelManager.fruitCounts.FirstOrDefault(x => x.fruitType == type);
        if (fruit)
        {
            isCorrect = true;
            Debug.LogError(isCorrect);
        }
        else
        {
            isCorrect = false;
            Debug.LogError(isCorrect);
        }
    }
}