using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    #region Fields
    PlayerControls inputActions;

    bool isMooving;
    Vector3 origPos, targetPos;
    float timeToMove = 0.2f;

    BoxCollider2D selfCollider;
    [SerializeField] LayerMask blockingLayer;
    #endregion

    #region Methods
    private void Awake()
    {
        inputActions = new PlayerControls();
        selfCollider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }


    void Update()
    {
        Vector2 direction = inputActions.Default.Move.ReadValue<Vector2>();
        if (!isMooving && Math.Abs(direction.x) != Math.Abs(direction.y) && !GameManager.Instance.isPaused) // убрать связь с LevelManager
        {
            TryMove(direction);
        }

    }

    private bool TryMove(Vector3 direction)
    {
        RaycastHit2D hit;

        origPos = transform.position;
        targetPos = origPos + direction;

        hit = Physics2D.Linecast(origPos, targetPos, blockingLayer);

        if (hit.collider != null)
            return false;
        else
        {
            StartCoroutine(Move(direction));
            return true;
        }
    }

    private IEnumerator Move(Vector3 direction)
    {
        isMooving = true;

        float elapsedTime = 0f;

        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = targetPos;

        isMooving = false;
    }
    #endregion

}
