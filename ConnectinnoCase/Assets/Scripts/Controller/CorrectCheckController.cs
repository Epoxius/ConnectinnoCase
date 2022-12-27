using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CorrectCheckController : MonoBehaviour
{
    public bool isCorrect;
    public void Check()
    {
        var levelData = GameManager.Instance.levelData;
        var levelCount = GameManager.Instance.levelManager._levelCount;
        for (int i = 0; i < levelData.levelData[levelCount].WaveDatas.Count; i++)
        {
            if (transform.name ==levelData.levelData[levelCount].WaveDatas[i].fruitName.ToString())
            {
                levelData.levelData[levelCount].WaveDatas[i].correctItemCount--;
                isCorrect = true;
                Debug.Log(isCorrect);
            }
            else
            {
                // transform.DOScale(Vector3.one / 1.5f, 1);
                // itemRb.isKinematic = true;
                isCorrect = false;
                Debug.Log(isCorrect);
            }
        }
    }
}