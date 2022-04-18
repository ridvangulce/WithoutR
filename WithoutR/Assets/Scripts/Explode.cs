using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosionEffect;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Police"))
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("Explode");
        }
    }
}