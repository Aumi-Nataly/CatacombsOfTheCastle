using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float SpeedMove;

    [SerializeField]
    private float SpeedRotation;

    private PlayerAction actions;
    private Rigidbody rb;
    private Vector2 MoveVector;
    private Vector3 DirRotation;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        actions = new PlayerAction();
    }

    private void OnMove(InputAction.CallbackContext context)
        => MoveVector = context.ReadValue<Vector2>();

    private void OnMoveCancel(InputAction.CallbackContext context)
    => MoveVector = Vector2.zero;

    private void OnEnable()
    {
        actions.Player.Enable();
        actions.Player.Move.performed += OnMove;
        actions.Player.Move.canceled += OnMoveCancel;
    }
    private void OnDisable()
    {
        actions.Player.Disable();
        actions.Player.Move.performed -= OnMove;
        actions.Player.Move.canceled -= OnMoveCancel;
    }


    private void FixedUpdate()
    {
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
            float turnAngle = input.x * SpeedRotation * Time.fixedDeltaTime;
            Quaternion delta = Quaternion.Euler(0, turnAngle, 0);
            rb.MoveRotation(rb.rotation * delta);   

        }

    }

}
