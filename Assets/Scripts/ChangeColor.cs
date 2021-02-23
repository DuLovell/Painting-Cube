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
    #endregion

    #region Methods
    private void Awake()
    {
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

            if (colorSelf == LevelManager.Instance.grassColor && colorPlayer == LevelManager.Instance.seedsColor)
                return;

            colorSelf = colorPlayer;
            spriteRendererSelf.color = colorSelf;

            // Запустить ивент
            if (colorSelf == winColor)
                EventManager.Instance.OnPlatformWinColorChange();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && colorSelf == LevelManager.Instance.seedsColor)
        {
            colorSelf = LevelManager.Instance.grassColor; // пометка
            spriteRendererSelf.color = colorSelf; // пометка
        } 
    }

    // Добавить функцию ChangeColor(Color color), чтобы не писать две помеченные строки
    #endregion
}
