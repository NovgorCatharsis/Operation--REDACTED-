using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector3 movementInputVector { get; private set; }
    public Vector2 mousePosition { get; private set; }
    public Vector2 mouseDelta { get; private set; }

    public event Action RightClickPressed;
    public event Action LeftClickPressed;

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
            RightClickPressed?.Invoke();
        }
    }

    private void OnLeftClick(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            LeftClickPressed?.Invoke();
        }
    }
}
