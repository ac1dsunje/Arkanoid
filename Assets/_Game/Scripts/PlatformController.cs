using UnityEngine;

namespace _Game.Scripts
{
public class PlatformController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveSpeed;
    private float _velocity;

    public PlatformController Construct(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
        return this;
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
