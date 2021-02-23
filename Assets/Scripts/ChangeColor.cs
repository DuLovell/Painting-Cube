using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ChangeColor : MonoBehaviour
{

    #region Fields
    SpriteRenderer spriteRendererSelf;
    Color colorSelf;
    Color colorPlayer;
    Color winColor;
    Light2D squareLight;
    #endregion

    #region Methods
    private void Awake()
    {
        squareLight = gameObject.transform.Find("Light").GetComponent<Light2D>();
        spriteRendererSelf = GetComponent<SpriteRenderer>();
        colorSelf = spriteRendererSelf.color;
    }

    private void Start()
    {
        winColor = LevelManager.Instance.seedsColor;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Color colorPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().color;
            colorSelf = colorPlayer;

            squareLight.color = colorSelf;
            squareLight.enabled = true;

            // Запустить ивент
            if (colorSelf == winColor)
                EventManager.Instance.OnPlatformWinColorChange();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && colorSelf == LevelManager.Instance.seedsColor)
        {
            colorSelf = LevelManager.Instance.grassColor;
        }
        
    }
    #endregion
}
