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
    #endregion

    private void Awake()
    {
        inputActions = new PlayerControls();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 direction = inputActions.Default.Move.ReadValue<Vector2>();
        if (!isMooving && Math.Abs(direction.x) != Math.Abs(direction.y))
        {
            StartCoroutine(Move(direction));
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
}
