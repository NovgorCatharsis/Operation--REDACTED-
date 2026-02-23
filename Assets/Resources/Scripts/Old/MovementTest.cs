// using UnityEngine;

// public class MovementTest : MonoBehaviour
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
//         playerInputConroller = playerObject.GetComponent<PlayerInputController>();
// 	}

//     void FixedUpdate()
//     {
//             Vector3 pointPosition = new Vector3(-playerInputConroller.mouseDelta.y,0,playerInputConroller.mouseDelta.x);
//             rigidBody.MovePosition(rigidBody.position+pointPosition * Time.fixedDeltaTime * moveSpeed);
//     }
// }