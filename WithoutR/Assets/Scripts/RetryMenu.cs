using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryMenu : MonoBehaviour
{
    public TextMeshProUGUI currentScore;
    public DestroyEnemy destroyEnemy;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public GameObject QuitButton;


    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}