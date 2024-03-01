using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyDestroyer : MonoBehaviour
{
    private Health _health;
    private EnemyAttacker _attacker;
    private EnemyMovement _movement;
    private EnemyPatrol _patrol;
    private EnemyFollow _follow;
    private float _animationDuration = 1f;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _attacker = GetComponent<EnemyAttacker>();
        _movement = GetComponent<EnemyMovement>();
        _follow = GetComponent<EnemyFollow>();
        _patrol = GetComponent<EnemyPatrol>();
    }

    private void OnEnable()
    {
        _health.ObjectDead += DestroyEnemy;
    }

    private void OnDisable()
    {
        _health.ObjectDead -= DestroyEnemy;
    }

    private void DestroyEnemy()
    {
        Destroy(_attacker);
        Destroy(_movement);
        Destroy(_follow);
        Destroy(_patrol);
        Destroy(gameObject, _animationDuration);
    }
}
