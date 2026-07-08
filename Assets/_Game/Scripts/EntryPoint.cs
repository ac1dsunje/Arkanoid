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
    [SerializeField] private GameObject _ballPrefab;

    private PlatformController _platform;

    private void Awake()
    {
        _bordersSpawner.Construct(_bordersSpawnerConfig, _cam.GetWidth(), _cam.GetHeight());
        CreatePlatform();
        CreateBall();
    }

    private void CreatePlatform()
    {
        _platform = Instantiate(_platformPrefab, new Vector2(0, -_cam.GetHeight() + 1f), Quaternion.identity)
            .GetComponent<PlatformController>();
    }

    private void CreateBall()
    {
        Instantiate(
            _ballPrefab, 
            new Vector2(_platform.BallSpawnPoint.position.x, _platform.BallSpawnPoint.position.y),
            Quaternion.identity, _platform.BallSpawnPoint);
    }
    
}
}