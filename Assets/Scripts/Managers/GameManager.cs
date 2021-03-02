using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public int plaformsNumber { get; private set; }
    [field: SerializeField] public CellType startPlayerType { get; private set; }
    [field: SerializeField] public int totalPoints { get; private set; }

    public bool isGameOver { get; private set; }

    // Singleton
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
    }

    private void Update()
    {
        // check for game end
        if (totalPoints == plaformsNumber)
        {
            EndLevel();
        }
    }

    private void EndLevel()
    {
        // disable player controls

        // check if we have set IsGameOver to true, only run this logic once
    }
}
