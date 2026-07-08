using UnityEngine;

namespace _Game.Scripts.Borders
{
public class BordersSpawner: MonoBehaviour
{
    private BordersSpawnerConfig _config;

    public void Construct(BordersSpawnerConfig config, float borderCenterX, float height)
    {
        _config = config;
        CreateBorders(borderCenterX, height);
    }
        
    private void CreateBorders(float borderCenterX, float height)
    {
        CreateSideBorder(borderCenterX, height * 2);
        CreateSideBorder(-borderCenterX, height * 2);

        var horizontalWidth = borderCenterX * 2;
        CreateUpperBorder(horizontalWidth, height);
        CreateLowerBorder(horizontalWidth, -height);
    }

    private void CreateSideBorder(float xOffset, float yScale)
    {
        CreateBorder(_config.BorderSidePrefab, 
            new Vector2(xOffset, 0), 
            new Vector3(_config.BorderWidth, yScale, _config.BorderWidth));
    }

    private void CreateUpperBorder(float xScale, float yOffset)
    {
        CreateBorder(_config.BorderUpPrefab, 
            new Vector2(0, yOffset), 
            new Vector3(xScale, _config.BorderWidth, _config.BorderWidth));
    }
        
    private void CreateLowerBorder(float xScale, float yOffset)
    {
        CreateBorder(_config.BorderDownPrefab, 
            new Vector2(0, yOffset), 
            new Vector3(xScale, _config.BorderWidth, _config.BorderWidth));
    }

    private void CreateBorder(GameObject prefab, Vector2 pos, Vector3 scale)
    {
        var border = Instantiate(prefab, pos, Quaternion.identity, transform).GetComponent<Transform>();
        border.localScale = scale;
    }
}
}