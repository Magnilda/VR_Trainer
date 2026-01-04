using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _questionText;

    [SerializeField]
    private Image _highlightImage;

    [SerializeField]
    private Color _correctColor;

    [SerializeField]
    private Color _incorrectColor;

    private bool _isAnswered = false;
    public Answer GetAnswer => _currentAnswer;
    private Answer _currentAnswer;

    private Action<AnswerManager> _onQuestionAnswered;

    public void InjectAnswer(Answer answer, Action<AnswerManager> OnQuestionAnswer)
    {
        _questionText.text = answer.Text;
        _currentAnswer = answer;
        _onQuestionAnswered = OnQuestionAnswer;
    }

    public void AnswerQuestion()
    {
        if (_isAnswered) return;
        _isAnswered = true;

        _onQuestionAnswered?.Invoke(this);
    }

    public void HighlightAnswer(bool isCorrect)
    {
        _highlightImage.color = isCorrect ? _correctColor : _incorrectColor;
    }
}
