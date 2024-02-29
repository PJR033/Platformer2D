using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event Action HealthHurted;
    public event Action ObjectDead;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float dealedDamage)
    {
        if (dealedDamage >= 0)
        {
            _currentHealth -= dealedDamage;
            HealthHurted?.Invoke();

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                ObjectDead?.Invoke();
                Destroy(gameObject);
            }
        }
    }

    public void TakeHeal(float healthHealed)
    {
        if (healthHealed >= 0)
        {
            _currentHealth += healthHealed;

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
    }
}
