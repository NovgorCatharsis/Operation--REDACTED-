using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OperativeDeath : MonoBehaviour
{
    [SerializeField] private AudioClip deathSound;
    private void Awake()
    {
    }
    public void Death()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.3f);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(MenuCountdown());
    }

    public IEnumerator MenuCountdown()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}