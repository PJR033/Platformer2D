using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyAttacker : Attacker
{
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayersHealth player))
        {
            player.TakeDamage(_damage);
        }
    }
}
