using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float _time = 120f;
    public TextMeshProUGUI text;
    public GameObject retryCanvas;
    public GameObject controlCanvas;
    public Animator animator;
    private static readonly int Time1 = Animator.StringToHash("time");

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
            if (_time < 10f)
            {
                animator.SetBool("time", true);
            }
        }


        else
        {
            PauseMenu.Current.gameIsPaused = true;
            retryCanvas.SetActive(true);
            controlCanvas.SetActive(false);
            AudioListener.volume = 0f;
            if (RewardAdControl.Current.isReward == true)
            {
                PauseMenu.Current.gameIsPaused = false;
                _time = 120f;
                retryCanvas.SetActive(false);
                controlCanvas.SetActive(true);
                Time.timeScale = 1f;
                AudioListener.volume = 1f;
                RewardAdControl.Current.isReward = false;
            }
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