using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CorrectCheckController : MonoBehaviour
{
    public bool isCorrect;
    public Rigidbody itemRb;
    public void Check(FruitType type)
    {
        var fruit = GameManager.Instance.levelManager.fruitCounts.FirstOrDefault(x => x.fruitType == type);
        if (fruit)
        {
            isCorrect = true;
            itemRb.isKinematic = true;
            transform.DOScale(Vector3.one / 1.5f, 1);
            Debug.LogError(isCorrect);
        }
        else
        {
            isCorrect = false;
            itemRb.isKinematic = false;
            transform.DOJump(new Vector3(0, 1, 0), 1, 1, 1);
            Debug.LogError(isCorrect);
        }
    }
}