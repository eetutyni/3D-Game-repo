using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }

    private Dictionary<string, Queue<GameObject>> objectPoolDictionary = new Dictionary<string, Queue<GameObject>>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddObjectToPool(GameObject obj, int count)
    {
        string objName = obj.name;
        if (!objectPoolDictionary.ContainsKey(objName))
        {
            objectPoolDictionary[objName] = new Queue<GameObject>();
        }

        for (int i = 0; i < count; i++)
        {
            GameObject newObj = Instantiate(obj);
            newObj.SetActive(false);
            objectPoolDictionary[objName].Enqueue(newObj);
        }
    }

    public GameObject GetObjectFromPool(GameObject obj)
    {
        string objName = obj.name;
        if (objectPoolDictionary.ContainsKey(objName) && objectPoolDictionary[objName].Count > 0)
        {
            GameObject objFromPool = objectPoolDictionary[objName].Dequeue();
            objFromPool.SetActive(true);
            return objFromPool;
        }
        else
        {
            return Instantiate(obj);
        }
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        objectPoolDictionary[obj.name].Enqueue(obj);
    }
}
