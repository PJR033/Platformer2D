using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayersAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRadius ;
    [SerializeField] private float _attackCooldown ;
    [SerializeField] private float _attackForce;
    [SerializeField] private Transform _attackPoint;

    public event Action AttackStarted;

    private Rigidbody2D _rigidbody;
    private bool _isCanAttack = true;
    private float _attackDelay = 0.4f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isCanAttack)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        WaitForSeconds attackDelay = new WaitForSeconds(_attackDelay);
        WaitForSeconds attackCooldown = new WaitForSeconds(_attackCooldown);
        AttackStarted?.Invoke();
        yield return attackDelay;
        List<Collider2D> colliders = new List<Collider2D>();
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = false;
        Physics2D.OverlapCircle(_attackPoint.position, _attackRadius, contactFilter, colliders);

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out EnemyAttacker enemy))
            {
                Health enemyHealth = enemy.GetComponent<Health>();
                Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
                enemyHealth.TakeDamage(_damage);
                enemyRigidbody.velocity = (enemyRigidbody.transform.position - _rigidbody.transform.position).normalized * _attackForce;
            }
        }

        _isCanAttack = false;
        yield return attackCooldown;
        _isCanAttack = true;
    }
}