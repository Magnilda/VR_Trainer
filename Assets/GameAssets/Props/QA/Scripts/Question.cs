using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Story/QA/Question")]
public class Question : ScriptableObject
{
    public string QuestionText;
    public List<Answer> Answers;
    public AudioClip CorrectAnswerVO;
    public AudioClip IncorrectAnswerVO;
}
