using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [HideInInspector] public bool gameIsPaused;

    public GameObject pauseMenuUI;

    public GameObject controlUI;

    // Update is called once per frame
    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Update()
    {
        if (gameIsPaused==true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
        controlUI.SetActive(true);
        AudioListener.volume = 1f;

    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
        controlUI.SetActive(false);
        AudioListener.volume = 0f;
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}