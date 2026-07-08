using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Blocks
{
public class BlocksSpawner: MonoBehaviour
{
    private readonly List<Vector2> _blocks = new();

    public void Construct(GameObject[] blockPrefabs, int blockPairs, float height, float size)
    {
        CreateMesh(blockPairs, height - size, size);
        CreateBlocks(blockPrefabs, size);
    }

    private void CreateMesh(int blockPairs, float height, float size)
    {
        for (var iy = size; iy < size*4; iy += size)
        {
            for (int i = 0; i < blockPairs; i++)
            {
                float ix = i * size + size / 2f;
                    
                _blocks.Add(new Vector2(-ix, height - iy));
                _blocks.Add(new Vector2(ix, height - iy));
            }
        }
    }

    private void CreateBlocks(GameObject[] blockPrefabs, float size)
    {
        foreach (var block in _blocks)
        {
            CreateBlock(blockPrefabs, block, size);
        }
    }

    private void CreateBlock(GameObject[] blockPrefabs, Vector2 pos, float scaleSize)
    {
        var blockPrefab = blockPrefabs[Random.Range(0, blockPrefabs.Length)];
        var block = Instantiate(blockPrefab, pos, Quaternion.identity, transform);
        block.transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
    }
}
}