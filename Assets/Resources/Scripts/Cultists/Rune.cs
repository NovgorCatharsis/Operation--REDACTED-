using UnityEngine;

public class Rune : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision happened");
        if (other.gameObject.CompareTag("Operative"))
        {
            Debug.Log("Operative collided with rune");
            other.gameObject.GetComponent<OperativeDeath>().Death();
        }
    }
}
