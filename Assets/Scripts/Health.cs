using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float _health;

    public void TakeDamage(float dealedDamage)
    {
        if (dealedDamage >= 0)
        {
            _health -= dealedDamage;

            if (_health <= 0)
            {
                _health = 0;
                Destroy(gameObject);
            }
        }
    }
}
