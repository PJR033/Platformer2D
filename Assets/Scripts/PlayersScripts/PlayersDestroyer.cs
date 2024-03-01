using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayersDestroyer : MonoBehaviour
{
    private Health _health;
    private PlayersMovement _movement;
    private PlayersAttacker _attacker;
    private PlayersWallet _wallet;
    private float _animationDuration = 0.4f;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _movement = GetComponent<PlayersMovement>();
        _attacker = GetComponent<PlayersAttacker>();
        _wallet = GetComponent<PlayersWallet>();

        Debug.Log("Destroyer is working");
    }

    private void OnEnable()
    {
        _health.ObjectDead += DestroyPlayer;
        Debug.Log("Destroyer is working");
    }

    private void OnDisable()
    {
        _health.ObjectDead -= DestroyPlayer;
    }

    private void DestroyPlayer()
    {
        Destroy(_movement);
        Destroy(_attacker);
        Destroy(_wallet);
        Destroy(gameObject, _animationDuration);
    }
}
