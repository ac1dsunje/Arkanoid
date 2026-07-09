using UnityEngine;

namespace _Game.Scripts
{
public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2.5f;
    private Rigidbody2D _rb;
    private float _velocity;

    public void Construct(Vector2 startPosition)
    {
        transform.position = startPosition;
    }
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _velocity = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityX = _velocity * _moveSpeed;
    }
}
}
