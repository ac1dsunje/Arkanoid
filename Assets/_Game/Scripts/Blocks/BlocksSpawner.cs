using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Blocks
{
public class BlocksSpawner: MonoBehaviour
{
    [SerializeField] private int _rows = 4;
    private readonly List<Vector2> _blocksPos = new();
    private BlockFactory _factory;

    public void Construct(int blockPairs, float height, float size, BlockFactory factory)
    {
        _factory = factory;
        CreateMesh(blockPairs, height - size, size);
        CreateBlocks();
    }

    private void CreateMesh(int blockPairs, float height, float size)
    {
        for (var iy = size; iy <= size * _rows; iy += size)
        {
            for (var i = 0; i < blockPairs; i++)
            {
                var ix = i * size + size / 2f;
                    
                _blocksPos.Add(new Vector2(-ix, height - iy));
                _blocksPos.Add(new Vector2(ix, height - iy));
            }
        }
    }

    private void CreateBlocks()
    {
        foreach (var blockPos in _blocksPos)
        {
            _factory.Get(blockPos, transform);
        }
    }
}
}