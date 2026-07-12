using _Game.Scripts.Blocks;
using _Game.Scripts.Borders;
using UnityEngine;

namespace _Game.Scripts
{
    public class EntryPoint: MonoBehaviour
    {
        [SerializeField] private CameraController _cam;
        [SerializeField] private BordersSpawnerConfig _bordersSpawnerConfig;
        [SerializeField] private BordersSpawner _bordersSpawner;
        [SerializeField] private float _borderWidth = 0.2f;
        
        [Header("Platform")]
        [SerializeField] private PlatformController _platform;
        [SerializeField] private float _platformSpawnOffset = 1f;
        
        [Header("Ball")]
        [SerializeField] private BallController _ball;
        
        [Header("Blocks")]
        [SerializeField] private GameObject[] _blockPrefabs;
        [SerializeField] private BlocksSpawner _blocksSpawner;
        [SerializeField] private float _blockSize = 0.2f;

        private void Awake()
        {
            var coordinator = new Coordinator(_cam.Width, _blockSize, _borderWidth);

            _bordersSpawner.Construct(_bordersSpawnerConfig, coordinator.BorderCenterX, _cam.Height);
            _blocksSpawner.Construct(_blockPrefabs, coordinator.BlockPairs, _cam.Height, _blockSize);
            
            var startPosition = new Vector2(0, -_cam.Height + _platformSpawnOffset);
            _platform.Construct(startPosition);
            
            _ball.Construct(_platform.transform);
        }
    }
}