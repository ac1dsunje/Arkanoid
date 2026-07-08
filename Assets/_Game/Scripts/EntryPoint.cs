using UnityEngine;

namespace _Game.Scripts
{
public class EntryPoint: MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private GameObject _borderPrefab;
    [SerializeField] private CameraController _cam;

    private void Awake()
    {
        CreateBorders();
        CreatePlatform();
    }

    private void CreateBorders()
    {
        var xOffset = _cam.GetWidth();
        var yScale = _cam.GetHeight() * 2;

        CreateBorder(xOffset, yScale);
        CreateBorder(-xOffset, yScale);
    }

    private void CreateBorder(float xOffset, float yScale)
    {
        var border = Instantiate(_borderPrefab, new Vector2(xOffset, 0), Quaternion.identity)
            .GetComponent<Transform>();
        border.localScale = new(border.localScale.x, yScale, border.localScale.z);
    }

    private void CreatePlatform()
    {
        Instantiate(_platformPrefab, new Vector2(0, -_cam.GetHeight() + 1f), Quaternion.identity);
    }
}
}