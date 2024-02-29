using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayersMovement : MonoBehaviour
{
    private const string Horizontal = ("Horizontal");
    private const string SpaceKey = "space";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    public event Action MovementHappened;
    public event Action JumpHappened;
    public event Action MovementStoped;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float directionX = Input.GetAxis(Horizontal);
        float distanceX = directionX * _speed * Time.deltaTime;

        if (directionX > 0)
        {
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 180;
            transform.rotation = Quaternion.Euler(rotate);
            MovementHappened?.Invoke();
            transform.Translate(distanceX * Vector2.left);
        }
        else if (directionX < 0)
        {
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 0;
            transform.rotation = Quaternion.Euler(rotate);
            MovementHappened?.Invoke();
            transform.Translate(distanceX * Vector2.right);
        }
        else
        {
            MovementStoped?.Invoke();
        }

        if (Input.GetKeyDown(SpaceKey))
        {
            JumpHappened?.Invoke();
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
}
