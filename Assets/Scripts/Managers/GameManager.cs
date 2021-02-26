using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    [SerializeField] ProgressBar progressBar;
    [SerializeField] GameObject hud;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject pauseScreen;
    [field: SerializeField] public int plaformsNumber { get; private set; }
    [field: SerializeField] public CellType startPlayerType { get; private set; }

    public bool isPaused { get; private set; }
    
    public static GameManager Instance
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
        progressBar.AddPoints();
    }

    public event Action onPlatformLoseColorChange;
    public void OnPlatformLoseColorChange()
    {
        if (onPlatformLoseColorChange != null)
            onPlatformLoseColorChange();
        progressBar.TakeAwayPoints();
    }

    public event Action onLevelEnd;
    public void OnLevelEnd()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;

        if (onLevelEnd != null)
            onLevelEnd();
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
            pauseScreen.SetActive(true);
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
        
    }
}
