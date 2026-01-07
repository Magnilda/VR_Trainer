using SaintsField;
using SaintsField.Playa;
using System;
using System.Collections;
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
    [SerializeField, ReadOnly]
    private GameObject _chapterContinueObject;

    [SerializeField]
    private GameObject _animationCompletePrefab;

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

        _chapterAnimationObject = Instantiate(_chapters[_activeChapter].AnimationObjectToSpawn);
    }

    [Button("Debug Start Continue Chapter")]
    public void OnAnimationComplete()
    {
        CleanupChapterAnimation();
        _chapterContinueObject = Instantiate(_animationCompletePrefab, transform);
    }

    [Button("Debug Start QA Chapter")]
    public void StartQAChapter()
    {
        CleanupContinueScreen();

        _chapterQAObject = Instantiate(_chapters[_activeChapter].QAObjectToSpawn, transform);
        QuestionManager questionManager = _chapterQAObject.GetComponent<QuestionManager>();
        questionManager.InjectQuestion(_chapters[_activeChapter].Question);
    }

    [Button("Debug Finish Chapter")]
    public void FinishChapter()
    {
        CleanupContinueScreen();
        CleanupChapterAnimation();
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

    private void CleanupContinueScreen()
    {
        if (_chapterContinueObject != null)
        {
            Destroy(_chapterContinueObject);
            _chapterContinueObject = null;
        }
    }
}
