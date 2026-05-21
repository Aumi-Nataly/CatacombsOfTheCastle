
using System.Diagnostics;

public class ChaseState : IEnemyState
{
    private Enemy _enemy;
    public ChaseState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Enter()
    {  
    }

    public void Exit()
    {
    }

    public void Update()
    {
        _enemy.Chase();
    }
}
