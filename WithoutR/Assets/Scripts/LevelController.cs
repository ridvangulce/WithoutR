using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Current;
    public bool gameActive;
    public GameObject startMenu, pauseMenu, restartMenu;
    void Start()
    {
        Current = this;
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        if (SceneManager.GetActiveScene().name == "Level" + currentLevel)
        {
            {
                SceneManager.LoadScene("Level" + currentLevel);
            }
        }
       
    }

    public void StartLevel()
    {
        gameActive = true;
    }
}