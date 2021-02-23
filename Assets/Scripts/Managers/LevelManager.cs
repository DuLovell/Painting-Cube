using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    static LevelManager instance;

    [SerializeField] ProgressBar progressBar;
    [SerializeField] GameObject hud;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject pauseScreen;
    [field: SerializeField] public int plaformsNumber { get; private set; }
    [field: SerializeField] public Color seedsColor { get; private set; }
    [field: SerializeField] public Color grassColor { get; private set; }
    [field: SerializeField] public Color playerColor { get; private set; }

    public bool isPaused { get; private set; }
    
    public static LevelManager Instance
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
        EventManager.Instance.onLevelWin += ShowWinMessage;
    }

    private void OnDisable()
    {
        EventManager.Instance.onPlatformWinColorChange -= OnPlatformWinColorChange;
        EventManager.Instance.onLevelWin -= ShowWinMessage;
    }

    void OnPlatformWinColorChange()
    {
        progressBar.SetPlatform();
    }

    private void ShowWinMessage()
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
