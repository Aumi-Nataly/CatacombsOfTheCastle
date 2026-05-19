using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private Queue<GameObject> pool = new Queue<GameObject>();

    public Pool(GameObject prefab, int poolSize)
    {
        for (int i = 0; i < poolSize; i++)        
        { 
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetFromPool()
    { 
        var obj = pool.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

}
