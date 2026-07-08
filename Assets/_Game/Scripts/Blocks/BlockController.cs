using UnityEngine;

namespace _Game.Scripts.Blocks
{
public class BlockController: MonoBehaviour
{
    [SerializeField] private int _health = 1;
    private Collider2D _collider2D;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            Destroy(gameObject);
    }
}
}