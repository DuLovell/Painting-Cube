using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Player : MonoBehaviour
{
    [field: SerializeField] public Color color { get; set; }


    private void Start()
    {
        color = LevelManager.Instance.playerColor; 
    }


}
