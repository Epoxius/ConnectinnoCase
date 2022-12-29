using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Lofelt.NiceVibrations;

public class CorrectCheckController : MonoBehaviour
{
    public bool isCorrect;
    public bool isDone;
    public Rigidbody itemRb;
    public void CheckIn(FruitType type)
    {
        var fruit = GameManager.Instance.levelManager.fruitCounts.FirstOrDefault(x => x.fruitType == type);
        if (fruit)
        {
            if (!isDone)
            {
                GameManager.Instance.soundManager.PlaySound(0); 
                transform.DOScale(Vector3.one / 1.2f, 1);
                if (GameManager.Instance.isVibrationOn)
                {
                    HapticPatterns.PlayPreset(HapticPatterns.PresetType.Success);
                }
               
            }
            else
            {
                GameManager.Instance.soundManager.PlaySound(1); 
                
                if (GameManager.Instance.isVibrationOn)
                {
                    HapticPatterns.PlayPreset(HapticPatterns.PresetType.LightImpact);
                }
                
                
            }
            
            isCorrect = true;
            itemRb.isKinematic = true;
            
            
            Debug.LogError(isCorrect);
        }
        else
        {
            GameManager.Instance.soundManager.PlaySound(1); 
            isCorrect = false;
            itemRb.isKinematic = false;
            transform.DOJump(new Vector3(0, 1, 0), 1, 1, 1);
            Debug.LogError(isCorrect);
        }
    }
    
    public void CheckisDoneControl()
    {
        var fruit = GameManager.Instance.levelManager.fruitCounts.FirstOrDefault(x =>
            transform.CompareTag(x.fruitType.ToString()));
        if (fruit)
        {
            if (fruit.fruitCount <= 0)
            {
               
                isDone = true;
                GameManager.Instance.soundManager.PlaySound(1);
                if (GameManager.Instance.isVibrationOn)
                {
                    HapticPatterns.PlayPreset(HapticPatterns.PresetType.LightImpact);
                }
                itemRb.isKinematic = false;
                transform.DOJump(new Vector3(0, 1, 0), 1, 1, 1);
                Debug.LogError(isCorrect);
            }
            else
            {
                isDone = false;
            }
        }
    }
}