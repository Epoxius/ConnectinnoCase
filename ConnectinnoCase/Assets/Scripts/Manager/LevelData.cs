using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public List<LevelDatas> levelData;
}

[System.Serializable]
public class LevelDatas
{
    public List<WaveData> WaveDatas;
}

[System.Serializable]
public class WaveData
{
    
    public FruitType fruitName;
    public int correctItemCount;
    
}
public enum FruitType
{
        apple,
        banana,
        cherry,
        cake,
        grape,
        watermelon,
        pumpkin
}