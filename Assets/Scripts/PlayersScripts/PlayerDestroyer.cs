using UnityEngine;

public class PlayerDestroyer : MonoBehaviour
{
    private PlayersMovement _movement;
    private PlayersAttacker _attacker;
    private PlayersWallet _wallet;
    private float _animationDuration = 0.8f;

    private void Awake()
    {
        _movement = GetComponent<PlayersMovement>();
        _attacker = GetComponent<PlayersAttacker>();
        _wallet = GetComponent<PlayersWallet>();
    }

    private void DestroyPlayer()
    {
        Destroy(_movement);
        Destroy(_attacker);
        Destroy(_wallet);
        Destroy(gameObject, _animationDuration);
    }
}
