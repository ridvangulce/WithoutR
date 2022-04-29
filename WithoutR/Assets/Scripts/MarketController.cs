using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketController : MonoBehaviour
{
    public GameObject marketCanvas;
    public GameObject menuCanvas;

    private bool _isOpen;


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