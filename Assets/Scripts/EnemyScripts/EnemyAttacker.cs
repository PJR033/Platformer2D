using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _attackForce;
    [SerializeField] private float _damage;
    [SerializeField] private float _damageDelay;

    private bool _isAttacking = false;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health player))
        {
            _isAttacking = true;
            StartCoroutine(DealDamage(player));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health player))
        {
            _isAttacking = false;
        }
    }

    private IEnumerator DealDamage(Health player)
    {
        var wait = new WaitForSeconds(_damageDelay);
        Rigidbody2D playersRigidbody = player.GetComponent<Rigidbody2D>();

        while (_isAttacking)
        {
            player.TakeDamage(_damage);
            playersRigidbody.velocity = (playersRigidbody.position - _rigidbody.position).normalized * _attackForce;
            yield return wait;
        }
    }
}