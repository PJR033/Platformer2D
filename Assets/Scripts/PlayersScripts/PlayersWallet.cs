using UnityEngine;

public class PlayersWallet : MonoBehaviour
{
    private int _coinsAmount = 0;

    public void IncreaseCoinsAmount()
    {
        _coinsAmount++;
    }
}
