using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    #region Fields
    [SerializeField] private LayerMask blockingLayer;

    private PlayerControls inputActions;

    private bool isMooving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    private BoxCollider2D selfCollider;
    
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


    private void Update()
    {
        Vector2 direction = inputActions.Default.Move.ReadValue<Vector2>();
        if (!isMooving && Math.Abs(direction.x) != Math.Abs(direction.y))
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
