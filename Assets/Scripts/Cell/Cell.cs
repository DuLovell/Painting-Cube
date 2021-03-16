using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Cell : MonoBehaviour
{

    #region Fields
    private SpriteRenderer spriteRendererSelf;
    private CellType playerType;
    private bool isWinType;

    [SerializeField] private CellType selfType;
    [SerializeField] private CellType winType;

    [SerializeField] private Sprite[] sprites = new Sprite[3];
    #endregion

    #region Properties
    public CellType SelfType { get { return selfType; } }
    public CellType WinType { get { return winType; } }
    #endregion

    #region Methods
    private void Awake()
    {
        spriteRendererSelf = GetComponent<SpriteRenderer>();
        CheckSelfType();
    }

    private void Update()
    {
        CheckSelfType();
    }

    private void CheckSelfType()
    {
        if (selfType == winType)
            isWinType = true;
        else if (selfType != CellType.Seeds)
            isWinType = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerType = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().type;

            if (selfType == CellType.Grass && playerType == CellType.Seeds || selfType == playerType)
                return;

            ChangeSelfType(playerType);
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
        
        if (cellType != CellType.Seeds)
        {
            ManageChangeInType();
        }
        
    }

    private void ManageChangeInType()
    {

        if (!isWinType && selfType == winType)
        {
            GameManager.Instance.AddPoints(winType);
        }
        else if (isWinType && selfType != winType)
        {
            GameManager.Instance.SubstractPoints(winType);
        }
    }
    #endregion
}
