using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float _time = 150f;
    public Text text;
    public GameObject retryCanvas;
    public GameObject controlCanvas;

    // Update is called once per frame
    private void Start()
    {
        gameObject.SetActive(false);
        retryCanvas.SetActive(false);
    }

    void Update()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
        }
        else
        {
            retryCanvas.SetActive(true);
            controlCanvas.SetActive(false);
            Time.timeScale = 0f;
            AudioListener.volume = 0f;
        }
        DisplayTime(_time);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            text.text = $"{minutes:00}:{seconds:00}";
        }
    }
}