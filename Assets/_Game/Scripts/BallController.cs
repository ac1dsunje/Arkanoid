using UnityEngine;

namespace _Game.Scripts
{
public class BallController : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public BallController AttachTo(Transform parent)
    {
        transform.SetParent(parent);
        return this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Release();
        }
    }

    private void Release()
    {
        transform.SetParent(null);
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _rb.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
    }
}
}