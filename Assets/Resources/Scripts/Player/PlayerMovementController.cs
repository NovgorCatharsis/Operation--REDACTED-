using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float flySpeed;
    [SerializeField] private float rotationSpeed;

    private PlayerInputController playerInputConroller;
    private CharacterController characterController;

    private void Awake()
    {
        playerInputConroller = GetComponent<PlayerInputController>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        movePlayer();
        playerLook();
    }


    private void movePlayer()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = playerInputConroller.movementInputVector.x; 
        moveDirection.y = playerInputConroller.movementInputVector.y; 
        moveDirection.z = playerInputConroller.movementInputVector.z;
        characterController.Move(transform.TransformDirection(moveDirection) * flySpeed * Time.deltaTime);
    }

    private void playerLook() 
    {
        transform.Rotate(Vector3.up * (playerInputConroller.rotateInputVector.x * Time.deltaTime) * rotationSpeed);
        //transform.Rotate(Vector3.up * (playerInputConroller.lookInputVector.x * Time.deltaTime) * xSens);
    }
}