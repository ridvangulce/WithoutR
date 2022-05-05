using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarketController : MonoBehaviour
{
    public GameObject marketCanvas;
    public GameObject menuCanvas;
    public TextMeshProUGUI scoreValue;
    public GameObject[] cars;
    [HideInInspector] public int selectedCar = 0;

    private bool _isOpen;

    public void NextCar()
    {
        cars[selectedCar].SetActive(false);
        selectedCar = (selectedCar + 1) % cars.Length;
        cars[selectedCar].SetActive(true);
    }

    public void PreviousCar()
    {
        cars[selectedCar].SetActive(false);
        selectedCar--;
        if (selectedCar<0)
        {
            selectedCar += cars.Length;
        }
        cars[selectedCar].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCar",selectedCar);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    private void Start()
    {
        scoreValue.text = ScoreManager.scorValue.ToString();
    }

    // Start is called before the first frame update
    public void ChangeOpen()
    {
        _isOpen = !_isOpen;
    }

    public void GoBack()
    {
        menuCanvas.SetActive(true);
        marketCanvas.SetActive(false);
        _isOpen = !_isOpen;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isOpen)
        {
            marketCanvas.SetActive(true);
        }
        else
        {
            _isOpen = false;
        }
    }
}