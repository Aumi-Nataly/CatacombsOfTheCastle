using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float SpeedMove;

    [SerializeField]
    private float SpeedRotation;

    [SerializeField]
    private float PowerJump;

    [SerializeField]
    private LayerMask groundMask;

    private PlayerAction actions;
    private Rigidbody rb;
    private Vector2 MoveVector;
    private Vector3 DirRotation;
    private bool InteractOn;
    private Animator animator;
    private bool isJump;

    public event Action OnInventoryClick;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        actions = new PlayerAction();

        Transform modelChild = transform.GetChild(0);
        animator = modelChild.GetComponent<Animator>();
    }

    private void OnMove(InputAction.CallbackContext context)
    { 
        MoveVector = context.ReadValue<Vector2>(); 
        animator.SetBool("IsRunning", true);
    }

    private void OnMoveCancel(InputAction.CallbackContext context)
    { 
        MoveVector = Vector2.zero;
        animator.SetBool("IsRunning", false);
    }

    private void OnInteract(InputAction.CallbackContext context)
    => InteractOn = true;

    private void InventoryClick(InputAction.CallbackContext context)
        => OnInventoryClick?.Invoke();

    private void OnJump(InputAction.CallbackContext context)
     => isJump = true;

    private void OnEnable()
    {
        actions.Player.Enable();
        actions.Player.Move.performed += OnMove;
        actions.Player.Move.canceled += OnMoveCancel;
        actions.Player.Interaction.performed += OnInteract;
        actions.Player.Inventory.performed += InventoryClick;
        actions.Player.Jump.performed += OnJump;
    }
    private void OnDisable()
    {
        actions.Player.Disable();
        actions.Player.Move.performed -= OnMove;
        actions.Player.Move.canceled -= OnMoveCancel;
        actions.Player.Interaction.performed -= OnInteract;
        actions.Player.Inventory.performed -= InventoryClick;
        actions.Player.Jump.performed -= OnJump;
    }


    public bool IsInteractOn() => InteractOn;
    public void ResetInteract() => InteractOn = false;

    private void FixedUpdate()
    {
        Jump();
        IsGround();

        Vector2 input = MoveVector;
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
        if (isJump && IsGround())
        {
            animator.SetBool("IsJumping", true);
            rb.AddForce(Vector3.up * PowerJump, ForceMode.Impulse);
        }

        isJump = false;
    }


    private void OnDrawGizmos()
    {
        var posline = transform.position + Vector3.up * 0.9f;
        var dic = Vector3.down * 1.1f;
        Debug.DrawRay(posline, dic, Color.red);
    }
}
