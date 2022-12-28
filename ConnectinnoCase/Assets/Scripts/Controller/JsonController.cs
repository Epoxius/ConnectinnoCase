using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonController : MonoBehaviour
{
    public GameData gameData;

    public string gameDataName = "gameData.json";
    public void SaveData()
    {
        PersistentData.WriteText(gameDataName,JsonConvert.SerializeObject(gameData));
    }

    public void LoadData()
    {
        string path = PersistentData.ReadText(gameDataName);
        if (string.IsNullOrEmpty(path) == false)
        {
            gameData = JsonConvert.DeserializeObject<GameData>(path);
        }
        else
        {
            gameData = new GameData(0, 3, 0, false);
        }
    }
}