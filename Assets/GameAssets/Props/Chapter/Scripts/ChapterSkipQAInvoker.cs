using UnityEngine;

public class ChapterSkipQAInvoker : MonoBehaviour
{
    public void Continue()
    {
        ChapterManager.Instance.FinishChapter();
    }
}
