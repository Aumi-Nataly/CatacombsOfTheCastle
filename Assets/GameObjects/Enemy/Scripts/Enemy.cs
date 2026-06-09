using System;
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

    [SerializeField]
    private int Health;

    public Action<GameObject> OnReturnPoolEnemy;

    private NavMeshAgent agent;
    private GameObject player;
    private EnemyStateMachine machine;
    private Animator animator;
    private Health playerHealth;
    private int CurrentHealth;
    private MusicManager _musicManager;

    public EnemyStateMachine enemyStateMachine => machine;

    public void Initialize(MusicManager musicManager)
    {
        _musicManager = musicManager;
    }    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        machine = new EnemyStateMachine();
        animator = childObject.GetComponent<Animator>();
         

    }

    private void OnEnable()
    {
        agent.enabled = true;
        CurrentHealth = Health;
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
        _musicManager.PlayEnemyGrowlSound();
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

    public void GetDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            machine.ChangeState(new DeadState(this));
        }
    }

    public void EnemyOff()
    {
        SetFlagStopped(true);
        agent.enabled = false;
        animator.SetTrigger("Dead");
    }

    public void ReturnToPool()
    {
        OnReturnPoolEnemy?.Invoke(gameObject);
    }
}
