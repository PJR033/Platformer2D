using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private EnemyAttacker _attacker;
    private EnemyMovement _movement;
    private EnemyPatrol _patrol;
    private EnemyFollow _follow;

    private void Awake()
    {
        _attacker = GetComponent<EnemyAttacker>();
        _movement = GetComponent<EnemyMovement>();
        _follow = GetComponent<EnemyFollow>();
        _patrol = GetComponent<EnemyPatrol>();
    }

    private void DestroyComponents()
    {
        Destroy(_attacker);
        Destroy(_movement);
        Destroy(_follow);
        Destroy(_patrol);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
