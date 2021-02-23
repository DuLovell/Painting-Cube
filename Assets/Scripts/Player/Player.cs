using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Player : MonoBehaviour
{
    [field: SerializeField] public Color color { get; set; }
    Light2D pointLight;

    private void Awake()
    {
        pointLight = GameObject.Find("Light").GetComponent<Light2D>();
    }

    private void Start()
    {
        color = LevelManager.Instance.playerColor; 
        pointLight.color = color;
    }


}
