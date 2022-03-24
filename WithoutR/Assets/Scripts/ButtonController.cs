using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private PrometeoCarController prometeoCarController;

    private void Start()
    {
        prometeoCarController = FindObjectOfType<PrometeoCarController>();
    }

    bool _isTurnRight;
    bool _isTurnLeft;
    private bool _isBrake;
    private bool _isAccel;

    private bool _stopBrake;
    private bool _stopTurn;
    private bool _stopAccel;


    /// <summary>
    /// POINTER UP - POINTER DOWN
    /// </summary>
    /// 
    /// <summary>
    /// Right Button Pointers
    /// </summary>
    public void RightPointerDown()
    {
        _stopTurn = false;
        Invoke("MakeRightVariableTrue", 0.005f);
    }

    public void RightPointerUp()
    {
        _isTurnRight = false;

        _stopTurn = true;
        if (_stopTurn == true)
        {
            prometeoCarController.steeringAxis = 0f;
        }
    }

    /// <summary>
    /// Left Button Pointers
    /// </summary>
    public void LeftPointerDown()
    {
        _stopTurn = false;
        Invoke("MakeLeftVariableTrue", 0.005f);
    }

    public void LeftPointerUp()
    {
        _isTurnLeft = false;
        _stopTurn = true;
        if (_stopTurn == true)
        {
            prometeoCarController.steeringAxis = 0f;
        }
    }

    /// <summary>
    /// Brake Pointers
    /// </summary>
    public void BrakePointerDown()
    {
        _stopBrake = false;
        Invoke("MakeBrakeVariableTrue", 0.005f);
    }

    public void BrakePointerUp()
    {
        _isBrake = false;

        _stopBrake = true;
      
    }

    /// <summary>
    /// Accel Pointers
    /// </summary>
    public void AccelPointerDown()
    {
        _stopAccel = false;
        Invoke("MakeAccelVariableTrue", 0.005f);
    }

    public void AccelPointerUp()
    {
        _isAccel = false;
        _stopAccel = true;
       
    }

    /// <summary>
    /// VARIABLES
    /// </summary>
    /// 
    /// <summary>
    /// Right Button Variable
    /// </summary>
    public void MakeRightVariableTrue()
    {
        _isTurnRight = true;
    }

    public void MakeRightVariableFalse()
    {
        _isTurnRight = false;
        if (_stopTurn == false)
        {
            Invoke("MakeRightVariableTrue", 0.005f);
        }
    }

    /// <summary>
    /// Left Button Variable
    /// </summary>
    public void MakeLeftVariableTrue()
    {
        _isTurnLeft = true;
    }

    public void MakeLeftVariableFalse()
    {
        _isTurnLeft = false;
        if (_stopTurn == false)
        {
            Invoke("MakeLeftVariableTrue", 0.005f);
        }
    }

    /// <summary>
    /// Brake Variable
    /// </summary>
    public void MakeBrakeVariableTrue()
    {
        _isBrake = true;
    }

    public void MakeBrakeVariableFalse()
    {
        _isBrake = false;
        if (_stopBrake == false)
        {
            Invoke("MakeBrakeVariableTrue", 0.005f);
        }
    }

    /// <summary>
    /// Accel Variable
    /// </summary>
    public void MakeAccelVariableTrue()
    {
        _isAccel = true;
    }

    public void MakeAccelVariableFalse()
    {
        _isAccel = false;
        if (_stopAccel == false)
        {
            Invoke("MakeAccelVariableTrue", 0.005f);
        }
    }


    private void FixedUpdate()
    {
        if (_isTurnRight == true)
        {
            MakeRightVariableFalse();
            prometeoCarController.TurnRight();
            Debug.Log("Turn Right");
        }

        if (_isTurnLeft == true)
        {
            MakeLeftVariableFalse();
            prometeoCarController.TurnLeft();
            Debug.Log("Turn Left");
        }

        if (_isBrake == true)
        {
            MakeBrakeVariableFalse();
            prometeoCarController.Handbrake();
            Debug.Log("Handbrake");
        }

        if (_isAccel == true)
        {
            MakeAccelVariableFalse();
            prometeoCarController.GoForward();
            Debug.Log("Go Forward");
            CancelInvoke("");
        }
    }
}