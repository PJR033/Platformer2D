using UnityEngine;

public class ItemsFinder : MonoBehaviour
{
    [SerializeField] private Health _playersHealth;
    [SerializeField] private PlayersWallet _wallet;

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
