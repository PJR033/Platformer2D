using UnityEngine;

[RequireComponent (typeof(EnemyFollow))]
[RequireComponent(typeof(EnemyPatrol))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private EnemyPatrol _enemyPatrol;
    private EnemyFollow _enemyFollow;
    private Player _player;
    private bool _isFollowing = false;

    private void Awake()
    {
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _enemyFollow = GetComponent<EnemyFollow>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _isFollowing = true;
            _player = player;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _isFollowing = false;
        }
    }

    private void Update()
    {
        if (_isFollowing)
        {
            _enemyFollow.Following(_speed, _player.transform.position);
        }
        else
        {
            _enemyPatrol.Patrolling(_speed);
        }
    }
}
