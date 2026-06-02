using System;
using UnityEngine;
public interface IInputSystem
{
    public event Action OnInventoryClick;
    public event Action OnPauseClick;
    public event Action OnDrinkBottleHealthClick;
    public event Action OnAttackClick;
    public Vector2 GetMoveVector();
    public bool GetInteractOn();
    public void ResetInteractOn();
    public bool GetJump();
    public void ResetJump();
    public void ResetAttack();
    public void AddAttack();

}
