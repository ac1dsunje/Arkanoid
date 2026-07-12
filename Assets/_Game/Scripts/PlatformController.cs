using UnityEngine;

namespace _Game.Scripts
{
public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2.5f;
    [SerializeField] private float _spawnOffset = 1f;
    
    private Rigidbody2D _rb;
   
    private float _velocity;

    public void Construct(float height)
    {
        transform.position = new Vector2(0, -height + _spawnOffset);;
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
