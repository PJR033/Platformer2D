using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;

    private Animator _animator;

    private int IsDead = Animator.StringToHash(nameof(IsDead));

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }

    public void TakeDamage(float dealedDamage)
    {
        float destroyDelay = 1;

        if (dealedDamage >= 0)
        {
            _health -= dealedDamage;
            Debug.Log("Õ¿Õ≈—≈Õ ”–ŒÕ ¬–¿√”");

            if (_health <= 0)
            {
                _health = 0;
                _animator.SetBool(IsDead, true);
                Destroy(gameObject, destroyDelay);
            }
        }
    }
}
