using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    public List<Pool> pools = new List<Pool>();
    public Transform poolTransform;

    private void Awake()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            

            Queue<GameObject> spawnQ = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject spawnObjet = Instantiate(pool.obj, poolTransform);
                spawnObjet.name = pool.obj.name;
                spawnObjet.SetActive(false);
                spawnQ.Enqueue(spawnObjet);
            }

            PoolDictionary.Add(pool.obj.name, spawnQ);
        }
    }


    public GameObject SpawnFromPool(string id)
    {
        if (!PoolDictionary.ContainsKey(id))
        {
            return null;
        }

        GameObject objectSpawn = PoolDictionary[id].Dequeue();
        objectSpawn.SetActive(true);
        return objectSpawn;
    }


    public void ObjectEnqueue(GameObject obj)
    {
        PoolDictionary[obj.name].Enqueue(obj);
        obj.SetActive(false);
    }
}

[System.Serializable]
public class Pool
{
    public GameObject obj;
    public int size;
}