using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void Start()
    {
        EventManager.Instance.onPlatformWinColorChange += OnPlatformWinColorChange;
        EventManager.Instance.onPlatformLoseColorChange += OnPlatformLoseColorChange;
        EventManager.Instance.onLevelWin += EndLevel;
    }

    private void OnDisable()
    {
        EventManager.Instance.onPlatformWinColorChange -= OnPlatformWinColorChange;
        EventManager.Instance.onPlatformLoseColorChange -= OnPlatformLoseColorChange;
        EventManager.Instance.onLevelWin -= EndLevel;
    }

    private void OnPlatformWinColorChange()
    {
        progressBar.AddPoints();
    }

    private void OnPlatformLoseColorChange()
    {
        progressBar.TakeAwayPoints();
    }

    private void EndLevel()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
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



    // GenerateLevel()
}
