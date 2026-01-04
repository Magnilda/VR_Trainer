using UnityEngine;

public class ChapterContinueInvoker : MonoBehaviour
{
    public void Continue()
    {
        ChapterManager.Instance.StartQAChapter();
    }
}
