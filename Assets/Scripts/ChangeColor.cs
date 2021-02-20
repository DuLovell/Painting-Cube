using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    #region Fields
    SpriteRenderer spriteRendererSelf;
    Color colorSelf;
    SpriteRenderer spriteRendererPlayer;
    bool isColored;
    #endregion

    #region Methods
    private void Awake()
    {
        spriteRendererSelf = GetComponent<SpriteRenderer>();
        colorSelf = spriteRendererSelf.color;

        spriteRendererPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isColored && collision.gameObject.CompareTag("Player"))
        {
            colorSelf = Color.white;
            spriteRendererSelf.color = colorSelf;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isColored && collision.gameObject.CompareTag("Player"))
        {
            colorSelf = spriteRendererPlayer.color;
            spriteRendererSelf.color = colorSelf;
            isColored = true;
        }
    }
    #endregion
}
