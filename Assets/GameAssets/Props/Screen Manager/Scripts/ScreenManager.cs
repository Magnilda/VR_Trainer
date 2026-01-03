using SaintsField;
using System;
using UnityEngine;

[Serializable]
public enum ScreenType
{
    StartScreen,
    QAScreen,
    VideoScreen,
    EndScreen,
}

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    private SaintsDictionary<ScreenType, Screen> _screenList;

    [SerializeField]
    private ScreenType _defaultScreen;

    [SerializeField, ReadOnly]
    private ScreenType _activeScreen;

    private void Start()
    {
        foreach (var screen in _screenList)
        {
            if (screen.Value.ShouldPreload())
            {
                screen.Value.Preload();
            }
        }

        SwitchScreen(_defaultScreen);
    }

    public void SwitchScreen(ScreenType screenType)
    {
        foreach (var screen in _screenList)
        {
            if (screen.Key != screenType)
                screen.Value.Hide();
        }
        _screenList[screenType].Show();
        _activeScreen = screenType;
    }

    public void LoadScreenAdditively(ScreenType screenType)
    {
        Screen selectedScreen = _screenList[screenType];

        if (!selectedScreen.activeSelf)
        {
            selectedScreen.transform.SetAsFirstSibling();
            selectedScreen.Show();
        }
    }

    public void UnloadScreen(ScreenType screenType)
    {
        _screenList[screenType].Hide();

        int amountOfActiveScreens = 0;
        foreach (var screen in _screenList)
        {
            if (screen.Value.activeSelf)
                amountOfActiveScreens++;
        }

        if(amountOfActiveScreens == 0)
        {
            SwitchScreen(_defaultScreen);
        }
    }
}
