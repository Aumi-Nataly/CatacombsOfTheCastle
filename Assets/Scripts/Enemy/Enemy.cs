using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private EnemyStateMachine machine;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        machine = new EnemyStateMachine();

    }

    private void Start()
    {
        machine.ChangeState(new ChaseState(this));
    }
    
    void Update()
    {
        machine.Update();
    }

    public void Chase()
    {
        agent.SetDestination(player.transform.position);
    }
}
