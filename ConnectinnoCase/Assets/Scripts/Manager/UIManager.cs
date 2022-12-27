using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Home Panel")] public GameObject homePanel;

    [Header("In Game Panel")] public List<Sprite> fruitSprites;
    public Image fruitSpriteObj;
    public RectTransform fruitTable;
    public TextMeshProUGUI gameLevelText;


    private void Update()
    {
      FruitTableControl();
    }

    public void FruitTableControl()
    {
        gameLevelText.text = "Level " + (GameManager.Instance.levelManager._levelCount +1);


            var levelData = GameManager.Instance.levelData;
        var levelCount = GameManager.Instance.levelManager._levelCount;

        
        for (int a = 0; a < fruitSprites.Count; a++)
        {
            for (int i = 0; i < levelData.levelData[levelCount].WaveDatas.Count; i++)
            {
                if (fruitSprites[a].name == levelData.levelData[levelCount].WaveDatas[i].fruitName.ToString())
                {
                    Image fruitSprite = Instantiate(fruitSpriteObj, fruitTable);

                    fruitSprite.sprite = fruitSprites[a];

                    fruitSprite.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                        levelData.levelData[levelCount].WaveDatas[i].correctItemCount.ToString();
                }
            }
        }
    }
}