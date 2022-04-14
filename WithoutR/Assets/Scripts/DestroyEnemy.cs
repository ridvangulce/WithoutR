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
    public GameObject prefab;
    public PathFollower pathFollower;
    [HideInInspector] public bool isDestroy;
    

   
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(collider.gameObject);
            isDestroy = true;
            Debug.Log(isDestroy);
            if (isDestroy == true)
            {
                StartCoroutine(SpawnCoroutine());
            }
        }
    }


    IEnumerator SpawnCoroutine()
    {
        Debug.Log("Start Coroutine");
        yield return new WaitForSeconds(5f);
        Instantiate(prefab, prefab.transform.position, Quaternion.identity);
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