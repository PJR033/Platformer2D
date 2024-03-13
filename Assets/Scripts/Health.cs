using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action HealthHurted;
    public event Action HealthChanged;
    public event Action ObjectDead;

    public float MaxHealth { get; private set; } = 100;
    public float CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float dealedDamage)
    {
        if (dealedDamage >= 0)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - dealedDamage, 0, MaxHealth);
            HealthHurted?.Invoke();
            HealthChanged?.Invoke();

            if (CurrentHealth == 0)
            {
                ObjectDead?.Invoke();
            }
        }
    }

    public void TakeHeal(float healthHealed)
    {
        if (healthHealed >= 0)
        {
            CurrentHealth += healthHealed;
            HealthChanged?.Invoke();

            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }
    }
}
