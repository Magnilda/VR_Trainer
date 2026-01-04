using UnityEngine;

public class ImageIndicator : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        transform.position = _target.position;
        transform.LookAt(_camera.transform);
    }
}
