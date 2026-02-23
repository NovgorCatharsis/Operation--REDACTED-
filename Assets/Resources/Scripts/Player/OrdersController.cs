using System;
using UnityEngine;
public class OrdersController : MonoBehaviour
{
    private PlayerInputController playerInputController;
    private EnemyController enemyController;
    public event Action Moved;
    
    public Vector3 targetedPosition;
    private RaycastHit hit;
    private Ray ray;

	private void Awake () 
    {
        playerInputController = gameObject.GetComponent<PlayerInputController>();
        playerInputController.RightClickPressed += MoveUnits;
        playerInputController.LeftClickPressed += MarkEnemy;
	}

    private void MoveUnits()
    {
        ray = Camera.main.ScreenPointToRay(playerInputController.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            targetedPosition = hit.point;
            Moved?.Invoke();
            Debug.Log(targetedPosition);
        } 
    }

    private void MarkEnemy()
    {
        ray = Camera.main.ScreenPointToRay(playerInputController.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == null) return;
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                Debug.Log(hit.transform.gameObject.name);
                enemyController = hit.transform.gameObject.GetComponent<EnemyController>();

                enemyController.isMarked = true;
                hit.transform.GetChild(0).gameObject.SetActive(true); // Marker visibility
            }   
        } 
    }
}