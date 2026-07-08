using System;
using UnityEngine;

namespace _Game.Scripts
{
public class CameraController: MonoBehaviour
{
    private Camera _cam;

    private void Awake()
    {
        _cam  = GetComponent<Camera>();
    }

    public float GetHeight()
    {
        return _cam.orthographicSize;
    }

    public float GetWidth()
    {
        return _cam.aspect * _cam.orthographicSize;
    }
}
}