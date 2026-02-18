using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector3 movementInputVector { get; private set; }
    public Vector2 mousePosition { get; private set; }

    public event Action RightClickPressed;

    private void OnMove(InputValue inputValue)
    {
        movementInputVector = inputValue.Get<Vector3>();
    }

    private void OnMousePosition(InputValue inputValue)
    {
        mousePosition = inputValue.Get<Vector2>();
    }

    private void OnRightClick(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            Debug.Log("2");
            RightClickPressed?.Invoke();
        }
    }
}
