
public class EnemyStateMachine
{
    private IEnemyState cur_state;

    public void ChangeState(IEnemyState new_state)
    {
        cur_state?.Exit();
        cur_state = new_state;
        cur_state?.Enter();
    }

    public void Update()
    {
        cur_state?.Update();
    }

}
