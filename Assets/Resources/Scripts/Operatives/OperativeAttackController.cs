using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OperativeAttackController : MonoBehaviour
{
    [SerializeField] private float reloadTime;
    [SerializeField] private float attackRange;

    private GameObject[] enemies;
    private GameObject attackTarget;
    private bool hasTarget;
    private RaycastHit hit;
   

    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

    }
    private void Update()
    {
        if (hasTarget) return; //If already attacking someone
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null) continue;
            if (enemies[i].GetComponent<EnemyController>().isMarked == false) continue;
            //if (Physics.Raycast(transform.position, enemies[i].transform.position, out hit, attackRange))
            if (Vector3.Distance(transform.position,enemies[i].transform.position) < attackRange)
            {
                hasTarget = true;
                Shoot(enemies[i]);
            }
        }
    }


    private void Shoot(GameObject target)
    {
        Debug.Log("SHOOTING");
        Destroy(target);
        StartCoroutine(Reload());
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        hasTarget = false;
    }
}