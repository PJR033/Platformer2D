using UnityEngine;

public class PlayersFinder : MonoBehaviour
{
    public PlayersMovement Player { get; private set; }
    public bool IsFollowing { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayersMovement player))
        {
            IsFollowing = true;
            Player = player;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayersMovement player))
        {
            IsFollowing = false;
        }
    }
}
