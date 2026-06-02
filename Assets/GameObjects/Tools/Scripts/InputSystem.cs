using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem: IInputSystem
{
    public event Action OnInventoryClick;
    public event Action OnPauseClick;
    public event Action OnDrinkBottleHealthClick;
    public event Action OnAttackClick;

    private PlayerAction actions;
    private Vector2 MoveVector;
    private bool InteractOn;
    private bool isJump;


    public InputSystem()
    {
        actions = new PlayerAction();

        actions.Player.Enable();
        actions.Player.Move.performed += OnMove;
        actions.Player.Move.canceled += OnMoveCancel;
        actions.Player.Interaction.performed += OnInteract;
        actions.Player.Inventory.performed += InventoryClick;
        actions.Player.Jump.performed += OnJump;
        actions.Player.Pause.performed += OnPauseMenu;
        actions.Player.Healing.performed += OnDrinkBottleHealth;
        actions.Player.Attack.performed += OnAttack;
    }

    public Vector2 GetMoveVector() => MoveVector;

    public bool GetInteractOn() => InteractOn;

    public void ResetInteractOn() => InteractOn = false;

    public bool GetJump() => isJump;

    public void ResetJump() => isJump = false;

    public void ResetAttack()
    {
        actions.Player.Attack.performed -= OnAttack;
    }

    public void AddAttack()
    {
        actions.Player.Attack.performed += OnAttack;
    }



    private void OnAttack(InputAction.CallbackContext context)
     => OnAttackClick?.Invoke();

    private void OnDrinkBottleHealth(InputAction.CallbackContext context)
    => OnDrinkBottleHealthClick?.Invoke();

    private void OnPauseMenu(InputAction.CallbackContext context)
    => OnPauseClick?.Invoke();

    private void OnJump(InputAction.CallbackContext context) => isJump = true;

    private void InventoryClick(InputAction.CallbackContext context)
    => OnInventoryClick?.Invoke();

    private void OnInteract(InputAction.CallbackContext context) => InteractOn = true;

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveVector = context.ReadValue<Vector2>();
    }

    private void OnMoveCancel(InputAction.CallbackContext context)
    {
        MoveVector = Vector2.zero;
    }


}
