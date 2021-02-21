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
    bool isColored;
    #endregion

    #region Methods
    private void Awake()
    {
        spriteRendererSelf = GetComponent<SpriteRenderer>();
        colorSelf = spriteRendererSelf.color;

        colorPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isColored && collision.gameObject.CompareTag("Player"))
        {
            colorSelf = Color.white;
            //spriteRendererSelf.color = colorSelf;

            Light2D light = gameObject.transform.Find("Light").GetComponent<Light2D>();
            light.color = colorSelf;
            light.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isColored && collision.gameObject.CompareTag("Player"))
        {
            colorSelf = colorPlayer;
            //spriteRendererSelf.color = colorSelf;
            isColored = true;
            
            Light2D light = gameObject.transform.Find("Light").GetComponent<Light2D>();
            light.color = colorSelf;
            light.enabled = true;

            // Запустить ивент
            EventManager.Instance.OnPlatformColorChange();
        }
        
    }
    #endregion
}
