using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    static LevelManager instance;
    [field: SerializeField] public int plaformsNumber { get; private set; }
    [field: SerializeField] public Color winColor { get; private set; }
    [field: SerializeField] public Color playerColor { get; private set; }
    
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

    // GenerateLevel()
}
