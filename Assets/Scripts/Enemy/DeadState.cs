using System.Collections;
using UnityEngine;

public class DeadState : IEnemyState
{
    private Enemy _enemy;
    public DeadState(Enemy enemy)
    {
        _enemy = enemy;
    }
    public void Enter()
    {
        _enemy.EnemyOff();
        _enemy.StartCoroutine(Dead());
    }

    private IEnumerator Dead()
    {
        yield return new WaitForSeconds(2f); //для анимации смерти
        _enemy.ReturnToPool();
    }

    public void Exit()
    {
       
    }

    public void Update()
    {
        
    }
}
