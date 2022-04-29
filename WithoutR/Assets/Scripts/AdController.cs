using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using GoogleMobileAds;
using UnityEngine;

public class AdController : MonoBehaviour
{
    public static AdController Current;
    private InterstitialAd interstitialAd;
    public string adUnitId = "";

    private void Start()
    {
        this.RequestAndLoadInterstitialAd();
        MobileAds.Initialize(interstitialAd => { });
        
    }

    public void RequestAndLoadInterstitialAd()
    {
        if (this.interstitialAd != null)
        {
            this.interstitialAd.Destroy();
        }

        this.interstitialAd = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitialAd.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        if (this.interstitialAd.IsLoaded())
        {
            this.interstitialAd.Show();
            Time.timeScale = 0f;
        }

        StartCoroutine(Wait());
    }

    public void DestroyInterstitialAd()
    {
        if (this.interstitialAd!=null)
        {
            this.interstitialAd.Destroy();
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
        RequestAndLoadInterstitialAd();
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#endif

        // Initialize an InterstitialAd.
        this.interstitialAd = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitialAd.LoadAd(request);
    }
}