using UnityEngine;

public class ItemsFinder : MonoBehaviour
{
    private Health _playersHealth;
    private PlayersWallet _wallet;

    private void Awake()
    {
        _playersHealth = GetComponent<Health>();
        _wallet = GetComponent<PlayersWallet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MedicineChest medicineChest))
        {
            _playersHealth.TakeHeal(medicineChest.HealedHealth);
            Destroy(medicineChest.gameObject);
        }
        else if (collision.TryGetComponent(out Coin coin))
        {
            _wallet.IncreaseCoinsAmount();
            Destroy(coin.gameObject);
        }
    }
}
