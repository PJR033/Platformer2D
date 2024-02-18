using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] protected float _health;
    [SerializeField] protected float _damage;

    private int IsDead = Animator.StringToHash(nameof(IsDead));
    private Animator _animator;
    private float _maxHealth;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _maxHealth = _health;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }

    public void TakeDamage(float dealedDamage)
    {
        float destroyDelay = 1;

        if (dealedDamage >= 0)
        {
            _health -= dealedDamage;
            Debug.Log("Õ¿Õ≈—≈Õ ”–ŒÕ »√–Œ ”");

            if (_health <= 0)
            {
                _health = 0;
                _animator.SetBool(IsDead, true);
                Destroy(gameObject, destroyDelay);
            }
        }
    }

    public void TakeHeal(float healthHealed)
    {
        if (healthHealed > 0)
        {
            _health += healthHealed;

            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }

            Debug.Log($"»√–Œ  œŒÀ≈◊»À—ﬂ Õ¿ {healthHealed} ≈√Œ «ƒŒ–Œ¬‹≈ - {_health}");
        }
    }
}
