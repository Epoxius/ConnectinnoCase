using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> fruitList;
    public int instCount;
    public void Start()
    {
      //  SpawnCorrectItem();
      
        
    }

    public void SpawnCorrectItem()
    {
        var levelData = GameManager.Instance.levelData;
        var levelCount = GameManager.Instance.jsonController.gameData.levelCount;


        var poolManager = GameManager.Instance.poolManager;

        for (int i = 0; i < levelData.levelData[levelCount].WaveDatas.Count; i++)
        {
            var eachCorrect = levelData.levelData[levelCount].WaveDatas[i].correctItemCount;
            for (int j = 0; j < eachCorrect; j++)
            {
                var item = poolManager.SpawnFromPool(levelData.levelData[levelCount].WaveDatas[i].fruitName.ToString());
                item.transform.position = GetRandomPosition();
            }
        }
    }

    public void SpawnAll()
    {
        var poolManager = GameManager.Instance.poolManager;
        for (int a = 0; a < fruitList.Count; a++)
        {
            for (int i = 0; i < instCount; i++)
            {
                GameObject fruit = poolManager.SpawnFromPool(fruitList[a].name);
                fruit.transform.position = GetRandomPosition();
            }
        }
        
    }

    

    public Vector3 GetRandomPosition()
    {
        Vector3 randomPos = Random.insideUnitSphere;
        randomPos.y = 1;
        return randomPos * 1.3f;
    }
}