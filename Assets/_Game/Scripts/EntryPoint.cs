using _Game.Scripts.Blocks;
using _Game.Scripts.Borders;
using UnityEngine;

namespace _Game.Scripts
{
    public class EntryPoint: MonoBehaviour
    {
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private BordersSpawnerConfig _bordersSpawnerConfig;
        [SerializeField] private BordersSpawner _bordersSpawner;
        [SerializeField] private float _borderWidth = 0.2f;
        
        [Header("Platform")]
        [SerializeField] private GameObject _platformPrefab;
        [SerializeField] private float _moveSpeed = 1f;
        
        [Header("Ball")]
        [SerializeField] private GameObject _ballPrefab;
        
        [Header("Blocks")]
        [SerializeField] private GameObject[] _blockPrefabs;
        [SerializeField] private BlocksSpawner _blocksSpawner;
        [SerializeField] private float _blockSize = 0.2f;

        private PlatformController _platform;
        private BallController _ball;

        private void Awake()
        {
            float camHeight = _cameraController.GetHeight();
            float camWidth = _cameraController.GetWidth();

            float availableWidth = camWidth - (2 * _borderWidth);
            int blockPairs = Mathf.FloorToInt(availableWidth / (2 * _blockSize));
            blockPairs = Mathf.Max(0, blockPairs);

            float halfBlocksWidth = blockPairs * _blockSize;
            float borderCenterX = halfBlocksWidth + (_borderWidth / 2f);

            _bordersSpawner.Construct(_bordersSpawnerConfig, borderCenterX, camHeight);
            _blocksSpawner.Construct(_blockPrefabs, blockPairs, camHeight, _blockSize);
            
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
                    new Vector2(_platform.transform.position.x, _platform.transform.position.y + 0.2f), 
                    Quaternion.identity);

            _ball = ballObj.GetComponent<BallController>().AttachTo(_platform.transform);
        }
    }
}