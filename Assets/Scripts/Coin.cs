using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        float destroyDelay = 0.75f;

        if (other.gameObject.TryGetComponent(out PlayersMovement player))
        {
            _audioSource.Play();
            Destroy(gameObject, destroyDelay);
        }
    }

}
