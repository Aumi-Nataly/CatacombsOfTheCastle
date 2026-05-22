using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float AttackDistance;

    [SerializeField]
    private int DamageValue;

    [SerializeField]
    private GameObject childObject;

    private NavMeshAgent agent;
    private GameObject player;
    private EnemyStateMachine machine;
    private Animator animator;
    private Health playerHealth;

    public EnemyStateMachine enemyStateMachine => machine;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        machine = new EnemyStateMachine();
        animator = childObject.GetComponent<Animator>();
         

    }

    private void Start()
    {
        playerHealth = player.GetComponent<Health>();

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

    public bool TargetIsNear()
    { 
        float distance = Vector3.Distance(transform.position, player.transform.position);

        return distance <= AttackDistance;
    }

    public void Attack()
    {
        playerHealth.TakeDamage(DamageValue);
    }

    public void PlayAttackAnimation(bool flag)
    {
        animator.SetBool("Attacking", flag);
    }

    public void SetFlagStopped(bool flag)
    {
        agent.isStopped = flag;
    }
}
