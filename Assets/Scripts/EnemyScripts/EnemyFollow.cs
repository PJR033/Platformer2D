using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public void Following(float speed, Vector2 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }
}
