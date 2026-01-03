using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance;

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
    private List<Screen> _screens;

    private void Start()
    {
        SwitchScreen(0);
    }

    public void SwitchScreen(int index)
    {
        for (int i = 0; i < _screens.Count; i++)
        {
            if (i == index)
            {
                _screens[i].gameObject.SetActive(true);
            }
            else
            {
                _screens[i].gameObject.SetActive(false);
            }
        }
    }
}
