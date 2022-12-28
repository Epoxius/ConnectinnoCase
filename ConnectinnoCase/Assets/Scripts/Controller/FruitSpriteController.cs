using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FruitSpriteController : MonoBehaviour
{
    [SerializeField] private Image fruitSprite;
    public  int fruitCount;
    [SerializeField] private TextMeshProUGUI countText;


    public void SetData(Sprite sprite, int _fruitCount,FruitType type )
    {
        fruitSprite.sprite = sprite;
        fruitCount = _fruitCount;
        countText.text = fruitCount.ToString();
        fruitType = type;
    }

    public FruitType fruitType;

    public void FruitControl()
    {
        fruitCount--;
        countText.text = fruitCount.ToString();
    }

    public bool FruitFinishControl()
    {
        return fruitCount == 0;
    }
    
  
}