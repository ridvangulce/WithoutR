using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using PathCreation.Examples;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private Coroutine _coroutine;
    public GameObject prefab;
    public PathFollower pathFollower;
    [HideInInspector]
    public bool _isDestroy;

    // Update is called once per frame

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Police"))
        {
            pathFollower.enabled = false;
            Destroy(gameObject);
            Debug.Log("Destroyed");
            _isDestroy = true;
        }
    }


    private void Update()
    {
        if (_isDestroy == true)
        {
            StartCoroutine(SpawnCoroutine());
            _isDestroy = false;
        }
    }

    IEnumerator SpawnCoroutine()
    {
        Instantiate(prefab, transform.position, transform.rotation);
        Debug.Log("Spawned");
        yield return new WaitForSeconds(1);
    }

    public void Spawn()
    {
        if (pathFollower.enabled == false)
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}