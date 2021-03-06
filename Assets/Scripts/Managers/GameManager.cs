using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Linq;
using UnityEngine.SceneManagement;
using LevelManagement;

public class GameManager : MonoBehaviour
{
    #region Fields
    private Player_Movement playerControls;

    [SerializeField] private int objectiveScore = -1; // temp SF
    [SerializeField] private int currentScore = -1; // temp SF
    [SerializeField] private CellType startPlayerType = CellType.Ground; // temp SF

    [SerializeField] private bool isGameOver;
    #endregion


    #region Properties
    public int ObjectiveScore { get { return objectiveScore; } }
    public int CurrentScore { get { return currentScore; } }
    public CellType StartPlayerType { get { return startPlayerType; } }
    #endregion



    #region Singleton + Awake & OnDestroy Logic
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        playerControls = GameObject.FindObjectOfType<Player_Movement>();
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }

        SceneManager.sceneLoaded -= SetScore;
    }
    #endregion

    #region Methods
    private void Start()
    {
        SetScore();
        SceneManager.sceneLoaded += SetScore;
    }


    private void SetScore(Scene scene = default, LoadSceneMode mode = default)
    {
        objectiveScore = GameObject.FindObjectsOfType<Cell>().Where(cell => cell.WinType == CellType.Ground).Count();
        
        if (objectiveScore > 0)
        {
            currentScore = 0;
        }
        else
        {
            currentScore = -1;
        }

        isGameOver = false;

    }

    private void Update()
    {
        // check for game end
        if (CurrentScore == ObjectiveScore)
        {
            EndLevel();
        }
    }

    private void EndLevel()
    {
        // disable player controls
        if (playerControls != null)
        {
            playerControls.enabled = false;
        }

        // check if we have set IsGameOver to true, only run this logic once
        if (!isGameOver)
        {
            isGameOver = true;
            WinScreen.Open();
        }
    }

    public void AddPoints()
    {
        currentScore++;
    }

    public void SubstractPoints()
    {
        currentScore--;
    }
    #endregion

}
