
using System.Collections;
using UnityEngine;

public class AttackState : IEnemyState
{
    private Enemy _enemy;
    private Coroutine _attackCoroutine;

    public AttackState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Enter()
    {
        _enemy.SetFlagStopped(true);
        _enemy.PlayAttackAnimation(true);
        _attackCoroutine = _enemy.StartCoroutine(AttackCoroutine());
    }

    public void Exit()
    {
        if (_attackCoroutine != null)
        {
            _enemy.StopCoroutine(_attackCoroutine);
        }

        _enemy.PlayAttackAnimation(false);
    }

    public void Update()
    {
      //  _enemy.Attack();

        if (!_enemy.TargetIsNear())
        {
            _enemy.enemyStateMachine.ChangeState(new ChaseState(_enemy));
            return;
        }
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            _enemy.Attack();
            yield return new WaitForSeconds(1.5f); 
        }
    }
}
