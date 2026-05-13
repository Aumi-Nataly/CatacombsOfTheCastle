
using System;
using UnityEngine;
using VContainer;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int MaxHealth;

    //добавить разделение на игрока и врага

    private int CurrentHealth;
    private ISaveService _saveService;
    private IInventoryService _inventoryService;
    public event Action<int, int> OnHealthChanged;

    [Inject]
    public void Construct(ISaveService saveService, IInventoryService inventoryService)
    {
        _saveService = saveService;
        _inventoryService = inventoryService;
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
        OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }

    public int GetCurrent() => CurrentHealth;

    public int GetMax() => MaxHealth;

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Die();
        }
        OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }

    public void TakeHealth(int health)
    {
        if (_inventoryService.GetСoncreteItem(ItemType.HealthBottle) > 0)
        {
            CurrentHealth += health;
            CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
            OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);

            _inventoryService.Remove(ItemType.HealthBottle, 1);
        }


    }

    private void Die()
    {

    }
}
