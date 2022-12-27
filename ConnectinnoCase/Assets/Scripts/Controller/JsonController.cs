
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonController : MonoBehaviour
{
      public GameData gameData = new (0,0,0,false);

    
    public void SaveData()
    {
        
        
        string jsonString = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.dataPath+"/Saves/gameDatasJson.json",jsonString);
        Debug.Log(jsonString);
       
    }

    public void LoadData()
    {
        string path = Application.dataPath + "/Saves/gameDatasJson.json";
        if (File.Exists(path))
        {
            string takeJson = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(takeJson);
            Debug.Log(takeJson);
        }
        else
        {
            Debug.Log("No Data");   
        }
        
    }


}
