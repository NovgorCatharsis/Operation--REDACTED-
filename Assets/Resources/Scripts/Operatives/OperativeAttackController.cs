using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Resolvers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class OperativeAttackController : MonoBehaviour
{
    [SerializeField] private float reloadTime;
    [SerializeField] private float attackRange;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private AudioClip shootSound;

    private GameObject[] enemies;
    private int enemiesAmount;
    private GameObject attackTarget;
    private bool hasTarget;
    private bool reloaded = true;
    private RaycastHit hit;
   

    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesAmount = enemies.Length;
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
        
        Debug.Log(enemiesAmount);
        if (enemiesAmount == 0)
        { 
            Debug.Log("All enemies defeated!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //GameObject.Find("Ending").GetComponent<UIDocument>().enabled = true;
        }
    }


    private void Shoot(GameObject target)
    {
        Debug.Log("SHOOTING");
        AudioSource.PlayClipAtPoint(shootSound, transform.position, 0.4f);
        reloaded = false;

        Destroy(target);
        enemiesAmount--;
        StartCoroutine(Reload());
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        AudioSource.PlayClipAtPoint(reloadSound, transform.position, 0.6f);
        hasTarget = false;
        reloaded = true;
    }
}