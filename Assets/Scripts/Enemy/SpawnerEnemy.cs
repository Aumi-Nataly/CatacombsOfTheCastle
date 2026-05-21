using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabEnemy;

    [SerializeField]
    private int PoolSize;

    [SerializeField]
    private int WaveSize;

    [SerializeField]
    private float WaveTimeInside;


    private Pool pool;
    private List<int> ActiveEnemyList = new List<int>();

    private void Awake()
    {
        pool = new Pool(prefabEnemy, PoolSize, transform);

    }

    private void Start()
    {
         StartCoroutine(CreateWave());
    }

    private IEnumerator CreateWave()
    {
        for (int i = 0; i < WaveSize; i++)
        {
            var obj = pool.GetFromPool();
            ActiveEnemyList.Add(1);
          //  obj.transform.position = transform.position;
            yield return new WaitForSeconds(WaveTimeInside);
        }
    }
}
