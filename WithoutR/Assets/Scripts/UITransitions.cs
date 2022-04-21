using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;

public class UITransitions : MonoBehaviour
{
    public CinemachineVirtualCamera currentCamera;


    private void Start()
    {
        currentCamera.Priority++;
    }

    public void UpdateCamera(CinemachineVirtualCamera target)
    {
        currentCamera.Priority--;
        currentCamera = target;
        currentCamera.Priority++;
    }

    public void StartGame(CinemachineVirtualCamera target)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ScoreManager.scorValue = 0;
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}