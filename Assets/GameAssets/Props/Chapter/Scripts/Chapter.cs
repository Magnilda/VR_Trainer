using UnityEngine;

[CreateAssetMenu(fileName = "New Chapter", menuName = "Story/Chapter")]
public class Chapter : ScriptableObject
{
    public string ChapterName;
    public GameObject AnimationObjectToSpawn;
    public GameObject QAObjectToSpawn;
    public Question Question;
}
