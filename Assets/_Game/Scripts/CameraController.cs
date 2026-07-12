using UnityEngine;

namespace _Game.Scripts
{
public class CameraController: MonoBehaviour
{
    private Camera _cam;

    public float Height => _cam.orthographicSize;
    public float Width => _cam.aspect * _cam.orthographicSize;

    private void Awake()
    {
        _cam  = GetComponent<Camera>();
    }
}
}