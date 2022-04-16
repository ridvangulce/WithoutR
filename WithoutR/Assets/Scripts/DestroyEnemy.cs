using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using PathCreation.Examples;
using UnityEngine;
using UnityEngine.Serialization;

public class DestroyEnemy : MonoBehaviour
{
    private Coroutine _coroutine;
    public GameObject oldCar;
    public GameObject rallyCar;
    [HideInInspector] public bool isDestroy;
    [HideInInspector] public bool changePrefab;


    private void Start()
    {
        StartCoroutine(SpawnCoroutineOldCar());
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(collider.gameObject);
            isDestroy = true;
            if (isDestroy == true && changePrefab)
            {
                StartCoroutine(SpawnCoroutineOldCar());
                changePrefab = false;
            }
            if (isDestroy == true && !changePrefab )
            {
                StartCoroutine(SpawnCoroutineRallyCar());
                changePrefab = true;
            }
        }
    }


    IEnumerator SpawnCoroutineOldCar()
    {
        Debug.Log("Start Coroutine");
        yield return new WaitForSeconds(5f);
        Instantiate(oldCar, oldCar.transform.position, Quaternion.identity);
        Debug.Log("Spawned");
        isDestroy = false;
    }
    IEnumerator SpawnCoroutineRallyCar()
    {
        Debug.Log("Start Coroutine");
        yield return new WaitForSeconds(5f);
        Instantiate(rallyCar,rallyCar.transform.position, Quaternion.identity);
        Debug.Log("Spawned");
        isDestroy = false;
    }
   

    // public void Spawn()
    // {
    //     if (pathFollower.enabled == false)
    //     {
    //         Instantiate(prefab, transform.position, transform.rotation);
    //     }
    // }
}