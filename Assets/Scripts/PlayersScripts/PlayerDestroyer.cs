using UnityEngine;

public class PlayerDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject _healthBarImages;
    
    private PlayersAttacker _attacker;
    private PlayersWallet _wallet;
    private PlayersMovement _movement;
    private float _animationDuration = 0.8f;

    private void Awake()
    {
        _movement = GetComponent<PlayersMovement>();
        _attacker = GetComponent<PlayersAttacker>();
        _wallet = GetComponent<PlayersWallet>();
    }

    private void DestroyPlayer()
    {
        Destroy(_healthBarImages);
        Destroy(_movement);
        Destroy(_attacker);
        Destroy(_wallet);
        Destroy(gameObject, _animationDuration);
    }
}
