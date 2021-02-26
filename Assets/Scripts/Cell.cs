using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Cell : MonoBehaviour
{

    #region Fields
    SpriteRenderer spriteRendererSelf;
    CellType playerType;
    bool isWinType;

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
    }

    private void Start()
    {
        ChangeSelfType(CellType.Grass);
        ManageChangeInType();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerType = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().type;

            if (selfType == CellType.Grass && playerType == CellType.Seeds || selfType == playerType)
                return;

            ChangeSelfType(playerType);
            ManageChangeInType();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && selfType == CellType.Seeds)
        {
            ChangeSelfType(CellType.Grass);
            ManageChangeInType();
        } 
    }

    private void ChangeSelfType(CellType cellType)
    {
        selfType = cellType;
        spriteRendererSelf.sprite = sprites[(int)selfType];    
    }

    private void ManageChangeInType()
    {
        if (!isWinType && selfType == winType)
        {
            EventManager.Instance.OnPlatformWinColorChange();
            isWinType = true;
        }
        else if (isWinType && selfType != winType)
        {
            EventManager.Instance.OnPlatformLoseColorChange();
            isWinType = false;
        }
    }
    #endregion
}
