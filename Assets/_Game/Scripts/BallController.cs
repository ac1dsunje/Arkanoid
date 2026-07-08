using UnityEngine;

namespace _Game.Scripts
{
public class BallController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void Construct(Transform parent, float speed)
    {
        transform.SetParent(parent);
        _speed  = speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.parent)
        {
            Release();
        }
        
    }

    private void Release()
    {
        transform.SetParent(null);
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _rb.AddForce(new Vector2(0, _speed), ForceMode2D.Impulse);
    }
}
}