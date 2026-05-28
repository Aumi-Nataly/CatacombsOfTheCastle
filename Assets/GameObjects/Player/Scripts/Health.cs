
using System;
using UnityEngine;
using VContainer;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int MaxHealth;

    [SerializeField]
    private int DefaultHealth;

    private int CurrentHealth;


    private IInventoryService _inventoryService;
    public event Action<int, int> OnHealthChanged;

    [Inject]
    public void Construct(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    private void Start()
    {
        CurrentHealth = PlayerPrefs.GetInt("CurrentPlayerHealth", DefaultHealth);
        OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("CurrentPlayerHealth", CurrentHealth);
        PlayerPrefs.Save();
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
