using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayersAttacker : Attacker
{
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }
}
