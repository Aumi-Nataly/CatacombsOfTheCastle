using UnityEngine;

public class SpawnerBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBullet;

    [SerializeField]
    private int PoolSize;

    private Pool pool;

    private void Awake()
    {
        pool = new Pool(prefabBullet, PoolSize);
    }

    public void Shoot()
    {
        var bullet = pool.GetFromPool();
        bullet.transform.position = transform.position;

        var bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(transform.forward);
            bulletScript.OnReturnPool += ReturnToPool;
        }
    }

    private void ReturnToPool(GameObject bullet)
    {
        pool.ReturnToPool(bullet);
    }

}
