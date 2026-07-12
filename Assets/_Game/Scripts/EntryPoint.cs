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

            BlockFactory blockFactory = new(_blockPrefabs, _blockSize);
            _blocksSpawner.Construct(coordinator.BlockPairs, _cam.Height, _blockSize, blockFactory);
            
            _platform.Construct(_cam.Height);
            
            _ball.Construct(_platform.transform);
        }
    }
}