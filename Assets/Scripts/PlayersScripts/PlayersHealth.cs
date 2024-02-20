using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayersHealth : Health
{
    private float _maxHealth;

    private void Awake()
    {
        _maxHealth = _health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MedicineChest medicineChest))
        {
            TakeHeal(medicineChest.HealedHealth);
            Destroy(medicineChest.gameObject);
        }
    }

    private void TakeHeal(float healthHealed)
    {
        if (healthHealed > 0)
        {
            _health += healthHealed;

            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
        }
    }
}
