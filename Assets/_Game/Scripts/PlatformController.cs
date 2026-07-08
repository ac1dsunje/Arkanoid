using UnityEngine;

namespace _Game.Scripts
{
public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private Transform _ballSpawnPoint;

    public Transform BallSpawnPoint => _ballSpawnPoint;

    private Rigidbody2D _rb;
    
    private float _velocity;
    
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
