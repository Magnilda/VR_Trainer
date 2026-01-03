using UnityEngine;

public class Screen : MonoBehaviour
{
    private void ClickToContinue(int index)
    {
        ScreenManager.Instance.SwitchScreen(index);
    }
}
