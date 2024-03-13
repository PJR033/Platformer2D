using UnityEngine;

public class PlayersHealthBarFlipper : MonoBehaviour
{
    [SerializeField] private PlayersMovement _playersMovement;

    private void OnEnable()
    {
        _playersMovement.PlayerFlipped += FlipImage;
    }

    private void OnDisable()
    {
        _playersMovement.PlayerFlipped -= FlipImage;
    }

    private void FlipImage(float rotateY)
    {
        Vector3 rotate = transform.eulerAngles;

        rotate.y = rotateY;
        transform.localRotation = Quaternion.Euler(rotate);
    }
}
