using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    [SerializeField]
    private float TimeLife;

    [SerializeField]
    private int Damage;

    private Vector3 Direction;
    private Coroutine MovingBulletCoroutine;
    public Action<GameObject> OnReturnPool;

    private void Start()
    {
        MovingBulletCoroutine = StartCoroutine(MovingBullet());
    }

    private IEnumerator MovingBullet()
    {
        float elapsedTime = 0f;

        while (elapsedTime < TimeLife)
        {
            transform.Translate(Direction * Speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }
       
        OnReturnPool?.Invoke(gameObject);
    }


    /// <summary>
    /// Метод для установки направления по отношению родителя
    /// </summary>
    /// <param name="dir"></param>
    public void SetDirection(Vector3 dir)
    {
        Direction = dir;
    }


    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy>();
            enemy.GetDamage(Damage);
        }
    }
}
