using System;
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

    public event Action<GameOverType> OnGameOver;

    private Pool pool;
   private Stack<int> ActiveEnemyList = new Stack<int>();

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
            ActiveEnemyList.Push(i);

             var enemyScript = obj.GetComponent<Enemy>();
            if (enemyScript != null)
            { 
              enemyScript.OnReturnPoolEnemy += ReturnToPool;
            }
            
            yield return new WaitForSeconds(WaveTimeInside);
        }
    }

    private void ReturnToPool(GameObject enemy)
    {
        pool.ReturnToPool(enemy);
        ActiveEnemyList.Pop();

        if (ActiveEnemyList.Count == 0)
        {
            OnGameOver?.Invoke(GameOverType.Win);
        }
    }
}
