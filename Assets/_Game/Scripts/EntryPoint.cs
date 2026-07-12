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
        [SerializeField] private PlatformController _platform;
        
        [Header("Ball")]
        [SerializeField] private BallController _ball;
        
        [Header("Blocks")]
        [SerializeField] private GameObject[] _blockPrefabs;
        [SerializeField] private BlocksSpawner _blocksSpawner;
        [SerializeField] private float _blockSize = 0.2f;

        private void Awake()
        {
            var camWidth = _cameraController.GetWidth();
            var camHeight = _cameraController.GetHeight();

            var coordinator = new Coordinator(camWidth, _blockSize, _borderWidth);

            _bordersSpawner.Construct(_bordersSpawnerConfig, coordinator.BorderCenterX, camHeight);
            _blocksSpawner.Construct(_blockPrefabs, coordinator.BlockPairs, camHeight, _blockSize);
            
            var startPosition = new Vector2(0, -camHeight + 1f);
            _platform.Construct(startPosition);
            
            _ball.Construct(_platform.transform);
        }
    }
}