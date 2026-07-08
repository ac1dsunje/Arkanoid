using UnityEngine;

namespace _Game.Scripts.Borders
{
public class BordersSpawner: MonoBehaviour
{
    private BordersSpawnerConfig _config;
    private float _width;
    private float _height;
    
    public void Construct(BordersSpawnerConfig config, float width, float height)
    {
        _config = config;
        _width = width;
        _height = height;
        CreateBorders();
    }
    
    private void CreateBorders()
    {

        CreateSideBorder(_width, _height * 2);
        CreateSideBorder(-_width, _height * 2);

        CreateUpperBorder(_width * 2, _height);
        CreateLowerBorder(_width * 2, -_height);
    }

    private void CreateSideBorder(float xOffset, float yScale)
    {
        var border = Instantiate(_config.BorderSidePrefab, new Vector2(xOffset, 0), Quaternion.identity)
            .GetComponent<Transform>();
        border.localScale = new Vector3(_config.BorderWidth, yScale, _config.BorderWidth);
    }

    private void CreateUpperBorder(float xScale, float yOffset)
    {
        var border = Instantiate(_config.BorderUpPrefab, new Vector2(0, yOffset), Quaternion.identity)
            .GetComponent<Transform>();
        border.localScale = new Vector3(xScale, _config.BorderWidth, _config.BorderWidth);
    }
    
    private void CreateLowerBorder(float xScale, float yOffset)
    {
        var border = Instantiate(_config.BorderDownPrefab, new Vector2(0, yOffset), Quaternion.identity)
            .GetComponent<Transform>();
        border.localScale = new Vector3(xScale, _config.BorderWidth, _config.BorderWidth);
    }
}
}