using System;
using UnityEngine;
public class OrdersController : MonoBehaviour
{
    private PlayerInputController playerInputController;
    public event Action UnitsMoved;
    public Vector3 targetedPosition;
    private RaycastHit hit;
    private Ray ray;

	private void Awake () 
    {
        playerInputController = gameObject.GetComponent<PlayerInputController>();
        playerInputController.RightClickPressed += MoveUnits;
	}

    private void MoveUnits()
    {
        ray = Camera.main.ScreenPointToRay(playerInputController.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            targetedPosition = hit.point;
            targetedPosition = new Vector3 (targetedPosition.x, targetedPosition.y+0.1f, targetedPosition.z);
            UnitsMoved?.Invoke();
            Debug.Log(targetedPosition);
        } 
    }
}