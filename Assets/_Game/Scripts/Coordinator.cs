using UnityEngine;

namespace _Game.Scripts
{
public class Coordinator
{
    public int BlockPairs { get; private set; }
    public float BorderCenterX { get; private set; }
    
    public Coordinator(float camWidth, float blockSize, float borderWidth)
    {
        BlockPairs = CalculateBlockPairs(camWidth, borderWidth, blockSize);
        BorderCenterX = CalculateBorderCenterX(BlockPairs, blockSize, borderWidth);
    }

    private int CalculateBlockPairs(float camWidth, float borderWidth, float blockSize)
    {
        var availableWidth = camWidth - (2 * borderWidth);
        return Mathf.FloorToInt(availableWidth / (2 * blockSize));
    }

    private float CalculateBorderCenterX(float  blockPairs, float borderWidth, float blockSize)
    {
        return blockPairs * blockSize + (borderWidth / 2f);
    }
}
}