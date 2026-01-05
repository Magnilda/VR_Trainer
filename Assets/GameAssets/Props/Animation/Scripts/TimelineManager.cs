using UltEvents;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _playableDirector;

    [SerializeField]
    private bool _useAlternativeEnding = false;

    [SerializeField]
    private UltEvent _onAlternativeEnding;

    private void Start()
    {
        _playableDirector.stopped += OnTimelineFinished;
        _playableDirector.Play();
    }

    private void OnTimelineFinished(PlayableDirector obj)
    {
        if (_useAlternativeEnding)
        {
            _onAlternativeEnding.Invoke();
            return;
        }

        ChapterManager.Instance.OnAnimationComplete();
    }
}
