using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // [SerializeField] private GameObject playerObject;
    // [SerializeField] private float moveSpeed;
    // private OrdersController ordersController;
    // private PlayerInputController playerInputConroller;
    [SerializeField] private float reloadTime;
    [SerializeField] private float viewRange;
    [SerializeField] private float attackRange;

    public bool isMarked;
    private GameObject[] operatives;
    private GameObject attackTarget;
    private bool isReloaded;
    private RaycastHit hit;
   
    private NavMeshAgent agent;

    private void Awake()
    {
        isMarked = false;
        isReloaded = true;
        agent = gameObject.GetComponent<NavMeshAgent>();
        operatives = GameObject.FindGameObjectsWithTag("Operative");

    }
    private void Update()
    {
        if (attackTarget == null)
        {
            for (int i = 0; i < operatives.Length; i++)
            {
                if (operatives[i] == null) continue;
                //if (Physics.Raycast(transform.position, operatives[i].transform.position, out hit, viewRange))
                if (Vector3.Distance(transform.position,operatives[i].transform.position) < viewRange)
                {
                    attackTarget = operatives[i];
                    agent.SetDestination(operatives[i].transform.position);
                    Debug.Log("AGGRED");
                }
            }
        }
        else
        {
            agent.SetDestination(attackTarget.transform.position);
            if (Vector3.Distance(transform.position, attackTarget.transform.position) < attackRange)
            //if (Physics.Raycast(transform.position, attackTarget.transform.position, out hit, attackRange))
            {
                Attack(attackTarget);
            }
        }
    }


    private void Attack(GameObject target)
    {
        Debug.Log("KILLING");
        attackTarget = null;
        isReloaded = false;
        Destroy(target);
        StartCoroutine(Reload());
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        Debug.Log("RELOADED");
        isReloaded = true;
    }
}