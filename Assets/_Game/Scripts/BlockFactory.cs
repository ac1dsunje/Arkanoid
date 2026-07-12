using UnityEngine;

namespace _Game.Scripts
{
public class BlockFactory
{
    private readonly GameObject[] _prefabs;
    private readonly float _size;
    
    public BlockFactory(GameObject[] blockPrefabs, float scaleSize)
    {
        _prefabs = blockPrefabs;
        _size = scaleSize;
    }
    
    public void Get(Vector2 pos, Transform parent)
    {
        var blockPrefab = _prefabs[Random.Range(0, _prefabs.Length)];
        var block = Object.Instantiate(blockPrefab, pos, Quaternion.identity, parent);
        block.transform.localScale = new Vector3(_size, _size, _size);
    }
}
}