using UnityEngine;

public class MedicineChest : MonoBehaviour
{
    private float _healedHealth = 50;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.TakeHeal(_healedHealth);
            Destroy(gameObject);
        }
    }
}
