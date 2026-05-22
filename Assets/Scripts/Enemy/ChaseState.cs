
public class ChaseState : IEnemyState
{
    private Enemy _enemy;
    public ChaseState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Enter()
    {
        _enemy.SetFlagStopped(false);
    }

    public void Exit()
    {
    }

    public void Update()
    {
        _enemy.Chase();

        if (_enemy.TargetIsNear())
        {
            _enemy.enemyStateMachine.ChangeState(new AttackState(_enemy));
            return;
        }
    }
}
