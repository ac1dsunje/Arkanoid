using UnityEngine;

namespace _Game.Scripts
{
public class EntryPoint: MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private Vector2 _spawnPoint;
    [SerializeField] private GameObject _borderPrefab;
    [SerializeField] private float _xOffset = 5f;

    private void Awake()
    {
        CreateBorders();
        CreatePlatform();
    }

    private void CreateBorders()
    {
        Instantiate(_borderPrefab, new Vector2(_spawnPoint.x + _xOffset, _spawnPoint.y), Quaternion.identity);
        Instantiate(_borderPrefab, new Vector2(_spawnPoint.x - _xOffset, _spawnPoint.y), Quaternion.identity);
    }

    private void CreatePlatform()
    {
        Instantiate(_platformPrefab, _spawnPoint, Quaternion.identity);
    }
}
}