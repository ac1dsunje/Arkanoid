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
        [SerializeField] private float _ballSpeed = 5f;
        
        [Header("Blocks")]
        [SerializeField] private GameObject[] _blockPrefabs;
        [SerializeField] private BlocksSpawner _blocksSpawner;
        [SerializeField] private float _blockSize = 0.2f;

        private PlatformController _platform;

        private void Awake()
        {
            var camHeight = _cameraController.GetHeight();

            var blockPairs = GetBlockPairs(_cameraController.GetWidth(), _borderWidth, _blockSize);
            var borderCenterX = GetBorderCenterX(blockPairs, _blockSize, _borderWidth);

            _bordersSpawner.Construct(_bordersSpawnerConfig, borderCenterX, camHeight);
            _blocksSpawner.Construct(_blockPrefabs, blockPairs, camHeight, _blockSize);
            
            CreatePlatform();
            CreateBall();
        }

        private int GetBlockPairs(float camWidth, float borderWidth, float blockSize)
        {
            var availableWidth = camWidth - (2 * borderWidth);
            return Mathf.FloorToInt(availableWidth / (2 * blockSize));
        }

        private float GetBorderCenterX(int blockPairs, float blockSize, float borderWidth)
        {
            return blockPairs * blockSize + (borderWidth / 2f);
        }

        private void CreatePlatform()
        {
            _platform = Instantiate(_platformPrefab, new Vector2(0, -_cameraController.GetHeight() + 1f), Quaternion.identity)
                .GetComponent<PlatformController>().Construct(_moveSpeed);
        }

        private void CreateBall()
        {
            Instantiate(_ballPrefab, 
                    new Vector2(_platform.transform.position.x, _platform.transform.position.y + 0.2f), 
                    Quaternion.identity).GetComponent<BallController>().Construct(_platform.transform, _ballSpeed);
        }
    }
}