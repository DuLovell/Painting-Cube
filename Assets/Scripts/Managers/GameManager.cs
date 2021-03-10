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

    #region Score
    [SerializeField] private int objectiveScore; // temp SF
    [SerializeField] private int currentScore; // temp SF 
    #endregion

    #region Cells
    [SerializeField] private int totalGroundCells;
    [SerializeField] private int currentGroundCells;

    [SerializeField] private int totalGrassCells;
    [SerializeField] private int currentGrassCells; 
    #endregion


    [SerializeField] private CellType startPlayerType = CellType.Ground; // temp SF

    [SerializeField] private bool isGameOver;

    private string[] blockingScenes = new string[] { "MainMenu" };
    #endregion


    #region Properties

    #region Score
    public int ObjectiveScore { get { return objectiveScore; } }
    public int CurrentScore { get { return currentScore; } } 
    #endregion

    #region Cells
    public int TotalGroundCells { get { return totalGroundCells; } }
    public int CurrentGroundCells { get { return currentGroundCells; } }
    public int TotalGrassCells { get { return totalGrassCells; } }
    public int CurrentGrassCells { get { return currentGrassCells; } } 
    #endregion

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
        // Обновлять данные только при загрузке игровых сцен
        if (blockingScenes.Contains(scene.name))
        {
            return;
        }

        playerControls = GameObject.FindObjectOfType<Player_Movement>();

        #region Cells
        totalGrassCells = GameObject.FindObjectsOfType<Cell>().Where(cell => cell.WinType == CellType.Grass).Count();
        totalGroundCells = GameObject.FindObjectsOfType<Cell>().Where(cell => cell.WinType == CellType.Ground).Count();

        currentGroundCells = GameObject.FindObjectsOfType<Cell>().Where(cell => cell.SelfType == CellType.Ground && cell.WinType == CellType.Ground).Count();
        currentGrassCells = GameObject.FindObjectsOfType<Cell>().Where(cell => cell.SelfType == CellType.Grass && cell.WinType == CellType.Grass).Count(); 
        #endregion

        objectiveScore = totalGrassCells + totalGroundCells;

        if (objectiveScore > 0)
        {
            currentScore = totalGrassCells;
        }
        else
        {
            Debug.LogWarning("GAMEMANAGER SetScore Error: something went wrong with score initialising!");
        }

        GameMenu.Instance.RefreshCounters();

        isGameOver = false;

    }

    private void Update()
    {
        // check for game end
        if (CurrentScore == ObjectiveScore || (!blockingScenes.Contains(SceneManager.GetActiveScene().name) && playerControls == null))
        {
            EndLevel();
        }
    }

    public void EndLevel()
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
            if (playerControls == null)
            {
                LoseScreen.Open();
            }
            else
            {
                WinScreen.Open();
            }
            
        }
    }

    public void AddPoints(CellType cellType)
    {
        if (cellType == CellType.Grass)
        {
            currentGrassCells++;
        }
        else if (cellType == CellType.Ground)
        {
            currentGroundCells++;
        }

        currentScore = currentGrassCells + currentGroundCells;
        GameMenu.Instance.RefreshCounters();
    }

    public void SubstractPoints(CellType cellType)
    {
        if (cellType == CellType.Grass)
        {
            currentGrassCells--;
        }
        else if (cellType == CellType.Ground)
        {
            currentGroundCells--;
        }

        currentScore = currentGrassCells + currentGroundCells;
        GameMenu.Instance.RefreshCounters();
    }
    #endregion

}
