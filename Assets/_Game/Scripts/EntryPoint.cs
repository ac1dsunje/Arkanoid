using _Game.Scripts.Borders;
using UnityEngine;

namespace _Game.Scripts
{
public class EntryPoint: MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private CameraController _cam;
    [SerializeField] private BordersSpawnerConfig _bordersSpawnerConfig;
    [SerializeField] private BordersSpawner _bordersSpawner;

    private void Awake()
    {
        _bordersSpawner.Construct(_bordersSpawnerConfig, _cam.GetWidth(), _cam.GetHeight());
        CreatePlatform();
    }

    private void CreatePlatform()
    {
        Instantiate(_platformPrefab, new Vector2(0, -_cam.GetHeight() + 1f), Quaternion.identity);
    }
}
}