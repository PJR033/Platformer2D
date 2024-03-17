using UnityEngine;

public class PlayersHealthBarMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _offset;

    private void Update()
    {
        MoveHealthBar();
    }

    private void MoveHealthBar()
    {
        if (_player != null)
        {
            Vector2 healthBarPosition = _player.transform.position;

            healthBarPosition.y = _offset + healthBarPosition.y;
            transform.position = healthBarPosition;
        }
    }
}
