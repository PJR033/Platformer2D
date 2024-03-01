using UnityEngine;

[RequireComponent (typeof(EnemyFollow))]
[RequireComponent(typeof(EnemyPatrol))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayersFinder _locator;

    private EnemyPatrol _enemyPatrol;
    private EnemyFollow _enemyFollow;

    private void Awake()
    {
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _enemyFollow = GetComponent<EnemyFollow>();
    }

    private void Update()
    {
        if (_locator.IsFollowing)
        {
            _enemyFollow.Following(_speed, _locator.Player.transform.position);
        }
        else
        {
            _enemyPatrol.Patrolling(_speed);
        }
    }
}
