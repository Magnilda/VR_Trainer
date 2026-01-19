using UnityEngine;

public class LineIndicator : MonoBehaviour
{
    [SerializeField]
    private Transform _startCircle;

    [SerializeField]
    private Transform _startCircleFollowTarget;

    [SerializeField]
    private Transform _endCircle;

    [SerializeField]
    private Transform _endCircleFollowTarget;

    [SerializeField]
    private LineRenderer _lineRenderer;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        _startCircle.position = _startCircleFollowTarget.position;
        _endCircle.position = _endCircleFollowTarget.position;

        _startCircle.LookAt(_camera.transform);

        Vector3 viewportPoint = _camera.WorldToViewportPoint(_endCircle.position);
        viewportPoint.z = _camera.nearClipPlane;
        Vector3 pointOnNearPlane = _camera.ViewportToWorldPoint(viewportPoint);
        _endCircle.LookAt(pointOnNearPlane, _camera.transform.up);

        _lineRenderer.SetPosition(0, _startCircle.position);
        _lineRenderer.SetPosition(1, _endCircle.position);
    }
}
