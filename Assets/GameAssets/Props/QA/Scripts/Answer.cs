using UnityEngine;

[CreateAssetMenu(fileName = "New Answer", menuName = "Story/QA/Answer")]
public class Answer : ScriptableObject
{
    public bool isCorrect;
    public string Text;
}
