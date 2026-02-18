using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float flySpeed;

    private PlayerInputController playerInputConroller;
    private Rigidbody rigidBody;

    private Vector3 velocity;

    private void Awake()
    {
        playerInputConroller = gameObject.GetComponent<PlayerInputController>();
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        velocity = new Vector3
        (
            -playerInputConroller.movementInputVector.z,
            playerInputConroller.movementInputVector.y,
            playerInputConroller.movementInputVector.x
        ) 
        * flySpeed;

        rigidBody.linearVelocity = velocity;
    }
}