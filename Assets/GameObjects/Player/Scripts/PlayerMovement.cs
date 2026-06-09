
using UnityEngine;
using VContainer;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int BottleHealthValue;

    [SerializeField]
    private float SpeedMove;

    [SerializeField]
    private float SpeedRotation;

    [SerializeField]
    private float PowerJump;

    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private GameObject SpawnerBullet;

    private Rigidbody rb;
    private Animator animator;
    private Health health;

    private IInputSystem _inputSystem;
    private MusicManager _musicManager;

    [Inject]
    public void Construct(IInputSystem inputSystem, MusicManager musicManager)
    {
        _inputSystem = inputSystem;
        _musicManager = musicManager;
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        health = GetComponent<Health>();

        Transform modelChild = transform.GetChild(0);
        animator = modelChild.GetComponent<Animator>();
    }

    private void Start()
    {
        _inputSystem.OnDrinkBottleHealthClick += OnDrinkBottleHealth;
        _inputSystem.OnAttackClick += OnAttack;
    }


    private void OnDrinkBottleHealth()
    => health.TakeHealth(BottleHealthValue);

    private void OnAttack()
    {
        SpawnerBullet sp = SpawnerBullet.GetComponent<SpawnerBullet>();
        _musicManager.PlayBulletSound();
        sp.Shoot();
    }


    private void OnDisable()
    {
        _inputSystem.OnDrinkBottleHealthClick -= OnDrinkBottleHealth;
        _inputSystem.OnAttackClick -= OnAttack;
    }


    public bool IsInteractOn() => _inputSystem.GetInteractOn();
    public void ResetInteract() => _inputSystem.ResetInteractOn();

    private void Update()
    {
        Vector2 input = _inputSystem.GetMoveVector();

        if (input == Vector2.zero)
        {
            animator.SetBool("IsRunning", false);
            _musicManager.PlayRunPlayerSound(0f, IsGround());
        }
        else 
        {
            animator.SetBool("IsRunning", true);
            _musicManager.PlayRunPlayerSound(1f, IsGround());
        }
    }

    private void FixedUpdate()
    {
        Jump();
        IsGround();
       

        Vector2 input = _inputSystem.GetMoveVector();
        if (input.magnitude < 0.1f)
        {
            input = Vector2.zero;
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            rb.MoveRotation(rb.rotation);
            return;
        }

        input = input.normalized;

        // Движение вперёд/назад
        Vector3 movement = transform.forward * input.y * SpeedMove;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        //повоторы
        if (Mathf.Abs(input.x) > 0.1f)
        {
            float turnAngle = input.x * 45f * SpeedRotation * Time.fixedDeltaTime;
            Quaternion delta = Quaternion.Euler(0, turnAngle, 0);
            rb.MoveRotation(rb.rotation * delta);   

        }
 

    }

    private bool IsGround()
    {
        var posline = transform.position + Vector3.up * 0.9f;
        var dic = Vector3.down;
        bool isGrounded = Physics.Raycast(posline, dic, 1.1f, groundMask);

        if (!isGrounded && animator.GetBool("IsJumping"))
        {
            animator.SetBool("IsJumping", false);
        }

        return isGrounded;
    }

    private void Jump()
    {
        if (_inputSystem.GetJump() && IsGround())
        {
            _musicManager.PlayJumpPlayerSound();
            animator.SetBool("IsJumping", true);
            rb.AddForce(Vector3.up * PowerJump, ForceMode.Impulse);
        }

        _inputSystem.ResetJump();
    }


    private void OnDrawGizmos()
    {
        var posline = transform.position + Vector3.up * 0.9f;
        var dic = Vector3.down * 1.1f;
        Debug.DrawRay(posline, dic, Color.red);
    }
}
