using UnityEngine;
using UnityEngine.AI;

public class OperativeMovementController : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    private OrdersController ordersController;

    private NavMeshAgent agent;

    private void Awake () 
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        ordersController = playerObject.GetComponent<OrdersController>();
        ordersController.Moved += Moved;
	}

    void Moved()
    {
        if (ordersController.targetedPosition != null)
        {
            agent.SetDestination(ordersController.targetedPosition);
        }
    }
}