using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using PathCreation.Examples;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject oldCar;
    public GameObject rallyCar;
    [HideInInspector] public bool isDestroy;
    [HideInInspector] public bool changePrefab;
    public Timer timer;
    public GameObject waypointArrow;
    public AudioSource audioSource;
    public Animator animator;

    private void Start()
    {
        audioSource.Stop();
        StartCoroutine(SpawnCoroutineOldCar());
        waypointArrow.SetActive(false);
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(collider.gameObject);
            isDestroy = true;
            StartCoroutine(StartAnimator());
            ScoreManager.scorValue += 5;

            if (isDestroy == true && changePrefab)
            {
                StartCoroutine(SpawnCoroutineOldCar());
                changePrefab = false;
                isDestroy = false;
            }

            if (isDestroy == true && !changePrefab)
            {
                StartCoroutine(SpawnCoroutineRallyCar());
                changePrefab = true;
                isDestroy = false;
            }
            
            
            audioSource.Play();
            waypointArrow.SetActive(false);
            timer.gameObject.SetActive(false);

        }
    }


    IEnumerator SpawnCoroutineOldCar()
    {
        Debug.Log("Start Coroutine");
        yield return new WaitForSeconds(5f);
        Instantiate(oldCar, oldCar.transform.position, Quaternion.identity);
        Debug.Log("Spawned");
        isDestroy = false;
        timer._time = 90f;
        timer.gameObject.SetActive(true);
        waypointArrow.SetActive(true);
        audioSource.Stop();
    }


    IEnumerator SpawnCoroutineRallyCar()
    {
        Debug.Log("Start Coroutine");
        yield return new WaitForSeconds(5f);
        Instantiate(rallyCar, rallyCar.transform.position, Quaternion.identity);
        Debug.Log("Spawned");
        isDestroy = false;
        timer._time = 90f;
        timer.gameObject.SetActive(true);
        waypointArrow.SetActive(true);
        audioSource.Stop();
    }
    IEnumerator StartAnimator()
    {
        animator.SetBool("isDestroy",true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("isDestroy",false);

    }



    // public void Spawn()
    // {
    //     if (pathFollower.enabled == false)
    //     {
    //         Instantiate(prefab, transform.position, transform.rotation);
    //     }
    // }
}