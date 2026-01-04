using UnityEngine;

public class CameraMovementInvoker : MonoBehaviour
{
    [SerializeField]
    private Transform _targetToFollow;

    [SerializeField]
    private bool _instantSnapBackOnStop = false;

    public void FollowTarget()
    {
        CameraManager.Instance.FollowTarget(_targetToFollow);
    }

    public void StopFollowing()
    {
        CameraManager.Instance.StopFollowing(_instantSnapBackOnStop);
    }
}
