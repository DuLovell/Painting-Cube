using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    static EventManager instance;

    public static EventManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.LogError("Multiple instances of " + this.GetType().Name + " #1", gameObject);
            Debug.LogError("Multiple instances of " + this.GetType().Name + " #2", Instance.gameObject);
        }
    }

    public event Action onPlatformWinColorChange;
    public void OnPlatformWinColorChange()
    {
        if (onPlatformWinColorChange != null)
            onPlatformWinColorChange();
    }

    public event Action onPlatformLoseColorChange;
    public void OnPlatformLoseColorChange()
    {
        if (onPlatformLoseColorChange != null)
            onPlatformLoseColorChange();
    }

    public event Action onLevelWin;
    public void OnLevelWin()
    {
        if (onLevelWin != null)
            onLevelWin();
    }

    // onLevelLost

}
