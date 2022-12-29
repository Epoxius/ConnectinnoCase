using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;

public class JsonController : MonoBehaviour
{
    public GameData gameData;

    public string gameDataPath = "gameData.json";
    public void SaveData()
    {
           PersistentData.WriteText(gameDataPath,JsonConvert.SerializeObject(gameData));
    }

    public void LoadData()
    {
        string path = PersistentData.ReadText(gameDataPath);
       
        if (string.IsNullOrEmpty(path) == false)
        {
            gameData = JsonConvert.DeserializeObject<GameData>(path);
            Debug.Log(path);
        }
        else
        {
            gameData = new GameData(0, 3, 0, 0,false,1,1);
        }
    }
}