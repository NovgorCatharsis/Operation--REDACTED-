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

    private void Update()
    {
        if (agent.velocity == Vector3.zero)
        {
            GetComponent<AudioSource>().enabled = false;
        }
        else 
        {             
            GetComponent<AudioSource>().enabled = true; 
        }
    }

    void Moved()
    {
        if (ordersController.targetedPosition != null)
        {
            agent.SetDestination(ordersController.targetedPosition);
        }
    }
}