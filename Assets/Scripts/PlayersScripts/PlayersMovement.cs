using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayersMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string SpaceKey = "space";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private int isRunning = Animator.StringToHash(nameof(isRunning));

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
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
            _spriteRenderer.flipX = true;
            _animator.SetBool(isRunning, true);
        }
        else if (directionX < 0)
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool(isRunning, true);
        }
        else
        {
            _animator.SetBool(isRunning, false);
        }

        if (Input.GetKeyDown(SpaceKey))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }

        transform.Translate(distanceX * Vector2.right);
    }
}
