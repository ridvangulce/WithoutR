using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UITransitions : MonoBehaviour
{
    public Slider progressBar;
    private int _level;
    public GameObject menuCanvas;
    public GameObject loadingCanvas;

    private void Awake()
    {
        _level = SceneManager.GetActiveScene().buildIndex + 1;
    }


    public void StartGame()
    {
        menuCanvas.SetActive(false);
        loadingCanvas.SetActive(true);
        StartCoroutine(StartLoad(_level));
        ScoreManager.scorValue = 0;
    }

    IEnumerator StartLoad(int level)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(level);
        while (!asyncOperation.isDone)
        {
            progressBar.value = asyncOperation.progress;
            yield return null;
        }
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}