using System;
using System.Collections.Generic;
using UnityEngine;


public class PlayersAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _damageDelay;
    [SerializeField] private Transform _attackPoint;

    public event Action AttackStarted;

    private CapsuleCollider2D _attackCollider;

    private void Awake()
    {
        _attackCollider = _attackPoint.GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackStarted?.Invoke();
            List<Collider2D> colliders = new List<Collider2D>();
            ContactFilter2D contactFilter = new ContactFilter2D();
            contactFilter.useTriggers = false;
            Physics2D.OverlapCollider(_attackCollider, contactFilter, colliders);

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out EnemyAttacker enemy))
                {
                    Health enemyHealth = enemy.GetComponent<Health>();
                    enemyHealth.TakeDamage(_damage);
                }
            }
        }
    }
}