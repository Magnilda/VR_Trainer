using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _answerPrefab;

    [SerializeField]
    private Transform _answersParent;

    [SerializeField]
    private TextMeshProUGUI _questionText;

    [SerializeField]
    private AudioSource _audioSource;

    private bool _isAnswered = false;
    private Question _currectQuestion;

    private List<AnswerManager> _answerManagers = new();

    [SerializeField]
    private GameObject _clickToContinueScreen;

    [SerializeField]
    private float _delayBeforeFinishingChapter = 5f;

    public void InjectQuestion(Question question)
    {
        _questionText.text = question.QuestionText;
        _currectQuestion = question;

        foreach(Answer answer in question.Answers)
        {
            GameObject answerObj = Instantiate(_answerPrefab, _answersParent);
            AnswerManager answerManager = answerObj.GetComponent<AnswerManager>();
            answerManager.InjectAnswer(answer, OnQuestionAnswered);
            _answerManagers.Add(answerManager);
        }
    }

    public void OnQuestionAnswered(AnswerManager selectedAnswer)
    {
        if (_isAnswered) return;
        _isAnswered = true;

        StartCoroutine(PlayAnswerVO(selectedAnswer, selectedAnswer.GetAnswer.IsCorrect ? _currectQuestion.CorrectAnswerVO : _currectQuestion.IncorrectAnswerVO));
    }

    private IEnumerator PlayAnswerVO(AnswerManager selectedAnswer, AudioClip voClip)
    {
        _audioSource.clip = voClip;
        _audioSource.Play();

        if (selectedAnswer.GetAnswer.IsCorrect)
        {
            selectedAnswer.HighlightAnswer(true);
        }
        else
        {
            foreach (var answerManager in _answerManagers)
            {
                if (answerManager.GetAnswer.IsCorrect)
                {
                    answerManager.HighlightAnswer(true);
                    break;
                }
            }
            selectedAnswer.HighlightAnswer(false);
        }

        yield return new WaitUntil(() => !_audioSource.isPlaying);

        StartCoroutine(ActionAfterDelays(_delayBeforeFinishingChapter, () => _clickToContinueScreen.SetActive(true)));
    }

    private IEnumerator ActionAfterDelays(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }

    public void NextChapter()
    {
        ChapterManager.Instance.FinishChapter();
    }
}
