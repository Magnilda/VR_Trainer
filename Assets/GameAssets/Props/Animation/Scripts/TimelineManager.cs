using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _playableDirector;

    private void Start()
    {
        _playableDirector.stopped += OnTimelineFinished;
        _playableDirector.Play();
    }

    private void OnTimelineFinished(PlayableDirector obj)
    {
        ChapterManager.Instance.StartQAChapter();
    }
}
