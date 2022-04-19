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
    private Coroutine _coroutine;
    public GameObject oldCar;
    public GameObject rallyCar;
    [HideInInspector] public bool isDestroy;
    [HideInInspector] public bool changePrefab;
    public Timer timer;
    public GameObject explosionEffect;
    public GameObject waypointArrow;

    private void Start()
    {
        StartCoroutine(SpawnCoroutineOldCar());
        waypointArrow.SetActive(false);
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(collider.gameObject);
            isDestroy = true;
            if (isDestroy == true)
            {
                StartCoroutine(ExplodeCoroutine());
            }

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
            
            ScoreManager.scorValue += 100;
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
        timer._time = 120f;
        timer.gameObject.SetActive(true);
        waypointArrow.SetActive(true);
    }

    IEnumerator SpawnCoroutineRallyCar()
    {
        Debug.Log("Start Coroutine");
        yield return new WaitForSeconds(5f);
        Instantiate(rallyCar, rallyCar.transform.position, Quaternion.identity);
        Debug.Log("Spawned");
        isDestroy = false;
        timer._time = 120f;
        timer.gameObject.SetActive(true);
        waypointArrow.SetActive(true);
    }

    IEnumerator ExplodeCoroutine()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        yield return new WaitForSeconds(3f);
        Destroy(GameObject.FindWithTag("Effect"));
    }


    // public void Spawn()
    // {
    //     if (pathFollower.enabled == false)
    //     {
    //         Instantiate(prefab, transform.position, transform.rotation);
    //     }
    // }
}