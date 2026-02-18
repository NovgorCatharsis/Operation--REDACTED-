using UnityEngine;

public class OperativeMovementController : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float moveSpeed;
    private OrdersController ordersController;
    private PlayerInputController playerInputConroller;

    private Rigidbody rigidBody;
    private bool testBool = false;
    private void Awake () 
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        ordersController = playerObject.GetComponent<OrdersController>();
        ordersController.UnitsMoved += Move;


        playerInputConroller = gameObject.GetComponent<PlayerInputController>();

	}

    void FixedUpdate()
    {
            Vector3 pointPosition = new Vector3(-playerInputConroller.movementInputVector.z,0,playerInputConroller.movementInputVector.x);
            //Vector3 finalPosition = transform.position + pointPosition;
            //Debug.Log("FP: "+ finalPosition);
            rigidBody.MovePosition(transform.position+pointPosition * Time.fixedDeltaTime * moveSpeed);
        
        // if (ordersController.targetedPosition != null && testBool)
        // {
        //     Vector3 pointPosition = ordersController.targetedPosition;
        //     pointPosition.y = 0;
        //     Vector3 finalPosition = transform.position + pointPosition;
        //     Debug.Log("FP: "+ finalPosition);
        //     rigidBody.MovePosition(finalPosition * Time.fixedDeltaTime * moveSpeed);
        // }
    }
    private void Move()
    {
        testBool = true;
        //rigidBody.MovePosition(ordersController.targetedPosition);
    }
}