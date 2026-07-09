using UnityEngine;

namespace _Game.Scripts
{
public class BallController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void Construct(Transform platform)
    {
        transform.position = new Vector2(platform.position.x, 
            platform.position.y + platform.transform.localScale.y/2f + transform.localScale.y/2f);
        
        transform.SetParent(platform);
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