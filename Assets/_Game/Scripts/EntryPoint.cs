using _Game.Scripts.Borders;
using UnityEngine;

namespace _Game.Scripts
{
public class EntryPoint: MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private BordersSpawnerConfig _bordersSpawnerConfig;
    [SerializeField] private BordersSpawner _bordersSpawner;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private float _moveSpeed = 1f;

    private PlatformController _platform;
    private BallController _ball;

    private void Awake()
    {
        _bordersSpawner.Construct(_bordersSpawnerConfig, _cameraController.GetWidth(), _cameraController.GetHeight());
        CreatePlatform();
        CreateBall();
    }

    private void CreatePlatform()
    {
        _platform = Instantiate(_platformPrefab, new Vector2(0, -_cameraController.GetHeight() + 1f), Quaternion.identity)
            .GetComponent<PlatformController>().Construct(_moveSpeed);
    }

    private void CreateBall()
    {
        var ballObj = Instantiate(
                _ballPrefab, 
                new Vector2(_platform.transform.position.x, _platform.transform.position.y+0.2f), 
                Quaternion.identity);

        _ball = ballObj.GetComponent<BallController>().AttachTo(_platform.transform);
    }
    
}
}