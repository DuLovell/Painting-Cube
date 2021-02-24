using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Cell : MonoBehaviour
{

    #region Fields
    SpriteRenderer spriteRendererSelf;
    CellType playerType;

    [SerializeField] CellType selfType;
    [SerializeField] CellType winType;

    //[SerializeField] Sprite grassSprite;
    //[SerializeField] Sprite groundSprite;
    //[SerializeField] Sprite seedsSprite;
    [SerializeField] Sprite[] sprites = new Sprite[3];
    #endregion

    #region Methods
    private void Awake()
    {
        spriteRendererSelf = GetComponent<SpriteRenderer>();
        
        ChangeSelfType(CellType.Grass);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerType = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().type;

            if (selfType == CellType.Grass && playerType == CellType.Seeds)
                return;

            ChangeSelfType(playerType);

            // Запустить ивент
            if (selfType == winType)
                EventManager.Instance.OnPlatformWinColorChange();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && selfType == CellType.Seeds)
        {
            ChangeSelfType(CellType.Grass);
        } 
    }

    private void ChangeSelfType(CellType cellType)
    {
        selfType = cellType;
        spriteRendererSelf.sprite = sprites[(int)selfType];
    }
    #endregion
}
