using SaintsField;
using SaintsField.Playa;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    public static ChapterManager Instance;

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
    private List<Chapter> _chapters;

    [SerializeField]
    private UltEvent _onChapterFinished;

    [SerializeField, ReadOnly]
    private int _activeChapter;
    [SerializeField, ReadOnly]
    private GameObject _chapterAnimationObject;
    [SerializeField, ReadOnly]
    private GameObject _chapterQAObject;

    private void Start()
    {
        SetupChapter(0);
    }

    [Button("Debug Start Animation Chapter")]
    public void SetupChapter(int chapterIndex)
    {
        if (chapterIndex < 0 || chapterIndex >= _chapters.Count)
        {
            Debug.LogError("Invalid chapter index");
            return;
        }
        _activeChapter = chapterIndex;

        _chapterAnimationObject = Instantiate(_chapters[_activeChapter].AnimationObjectToSpawn, transform);
    }

    [Button("Debug Start QA Chapter")]
    public void StartQAChapter()
    {
        CleanupChapterAnimation();

        _chapterQAObject = Instantiate(_chapters[_activeChapter].QAObjectToSpawn, transform);
        //Inject question into QA object
    }

    [Button("Debug Finish Chapter")]
    public void FinishChapter()
    {
        CleanupChapterQA();

        if (_activeChapter + 1 < _chapters.Count)
        {
            SetupChapter(_activeChapter + 1);
        }
        else
        {
            Debug.Log("All chapters completed!");
            _onChapterFinished?.Invoke();
        }
    }

    private void CleanupChapterAnimation()
    {
        if (_chapterAnimationObject != null)
        {
            Destroy(_chapterAnimationObject);
            _chapterAnimationObject = null;
        }
    }

    private void CleanupChapterQA()
    {
        if (_chapterQAObject != null)
        {
            Destroy(_chapterQAObject);
            _chapterQAObject = null;
        }
    }
}
