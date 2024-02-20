using UnityEngine;

[RequireComponent (typeof(PlayersHealth))]
public class PlayersWallet : MonoBehaviour
{
    private int _coinsCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Coin coin))
        {
            _coinsCount++;
            Destroy(coin.gameObject);
        }
    }
}
