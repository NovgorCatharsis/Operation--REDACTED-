using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector3 movementInputVector { get; private set; }
    public Vector2 lookInputVector { get; private set; }
    public Vector2 rotateInputVector { get; private set; }

    public Vector2 mousePosition { get; private set; }
    //public Vector2 mouseDelta { get; private set; }

    public event Action RightClickPressed;
    public event Action LeftClickPressed;
    public event Action Overload;

    private void OnMove(InputValue inputValue)
    {
        movementInputVector = inputValue.Get<Vector3>();
    }

    private void OnLook(InputValue inputValue)
    {
        lookInputVector = inputValue.Get<Vector2>();
    }

    private void OnRotate(InputValue inputValue)
    {
        rotateInputVector = inputValue.Get<Vector2>();
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

    private void OnOverload(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            Debug.Log("Overload Pressed");
            Overload?.Invoke();
        }
    }
}
