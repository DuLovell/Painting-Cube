using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using LevelManagement;

public class Player : MonoBehaviour
{
    [field: SerializeField] public CellType type { get; set; }


    private void Start()
    {
        type = GameManager.Instance.StartPlayerType; 
    }
}
