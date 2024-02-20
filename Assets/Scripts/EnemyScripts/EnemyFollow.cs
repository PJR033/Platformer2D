using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private PlayersHealth _player;

    public bool IsFollowing { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayersHealth player))
        {
            IsFollowing = true;
            _player = player;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayersHealth player))
        {
            IsFollowing = false;
        }
    }

    public void Following(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
    }
}
