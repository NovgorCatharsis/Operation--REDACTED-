// using UnityEngine;

// public class OLD_OperativeMovementController : MonoBehaviour
// {
//     [SerializeField] private GameObject playerObject;
//     [SerializeField] private float moveSpeed;
//     private OrdersController ordersController;
//     private PlayerInputController playerInputConroller;

//     private Rigidbody rigidBody;
//     private bool testBool = false;
//     private void Awake () 
//     {
//         rigidBody = gameObject.GetComponent<Rigidbody>();
//         ordersController = playerObject.GetComponent<OrdersController>();
//         ordersController.UnitsMoved += Move;


//         playerInputConroller = gameObject.GetComponent<PlayerInputController>();

// 	}

//     void FixedUpdate()
//     {
//         if (ordersController.targetedPosition != null && testBool)
//         {
//             Vector3 pointPosition = ordersController.targetedPosition;
//             Vector3 finalPosition = rigidBody.position - pointPosition;
//             Debug.Log("FP: "+ finalPosition);
//             rigidBody.MovePosition(finalPosition * Time.fixedDeltaTime * moveSpeed);
//         }
//     }
//     private void Move()
//     {
//         testBool = true;
//         //rigidBody.MovePosition(ordersController.targetedPosition);
//     }
// }