using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    private bool _isWandering;
    private bool _isRotatingRight;
    private bool _isRotatingLeft;
    private bool isGo;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (_isWandering == false)
        {
            StartCoroutine(Wander());
        }

        if (_isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }

        if (_isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }

        if (isGo==true)
        {
            rb.AddForce(transform.forward*movementSpeed);
        }
    }

    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotateDirection = Random.Range(1, 3);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);
        _isWandering = true;
        yield return new WaitForSeconds(walkWait);
        isGo = true;
        yield return new WaitForSeconds(walkTime);
        isGo = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateDirection == 1)
        {
            _isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            _isRotatingLeft = false;
        }

        if (rotateDirection == 2)
        {
            _isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            _isRotatingRight = false;
        }

        _isWandering = false;
    }
}