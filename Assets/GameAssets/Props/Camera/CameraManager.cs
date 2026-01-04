using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    private float _followSpeed = 30.0f;

    [SerializeField]
    private float _goBackTimeInSeconds = 2.0f;

    private Transform _target;
    private Transform _cameraOrigin;

    public void FollowTarget(Transform target)
    {
        StopAllCoroutines();
        _target = target;
        StartCoroutine(InternalFollowTarget());
    }

    public void StopFollowing(bool instantSnapBack)
    {
        StopAllCoroutines();
        _target = null;
        StartCoroutine(LerpToOrigin(instantSnapBack));
    }

    private IEnumerator InternalFollowTarget()
    {
        while (_target != null)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _followSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, _target.rotation, Time.deltaTime * _followSpeed);
            yield return null;
        }
    }

    private IEnumerator LerpToOrigin(bool instantSnapBack)
    {
        if (instantSnapBack)
        {
            transform.position = _cameraOrigin.position;
            transform.rotation = _cameraOrigin.rotation;
        }
        else
        {
            float duration = _goBackTimeInSeconds;
            float elapsed = 0.0f;
            Vector3 startingPosition = transform.position;
            Quaternion startingRotation = transform.rotation;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / duration);
                transform.position = Vector3.Lerp(startingPosition, _cameraOrigin.position, t);
                transform.rotation = Quaternion.Slerp(startingRotation, _cameraOrigin.rotation, t);
                yield return null;
            }
            transform.position = _cameraOrigin.position;
            transform.rotation = _cameraOrigin.rotation;
        }
    }
}
