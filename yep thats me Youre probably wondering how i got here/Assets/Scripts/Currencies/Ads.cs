using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds;

public class Ads : MonoBehaviour
{
    private BannerView bannerView;
   

        public void Start()
    {
        DontDestroyOnLoad(this);

        string appId = "ca-app-pub-5174796967747907~9932595147";


        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        this.RequestBanner();
        this.RequestInterstitial();
    }

    private void RequestBanner()
    {
    
        string bannerAd = "ca-app-pub-5174796967747907/7818841153";

        BannerView bannerView = new BannerView(bannerAd, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);

        
    }
    private InterstitialAd interstitial;

    private void RequestInterstitial()
    {
        

        string adUnitId = "ca-app-pub-5174796967747907/8588997346";

        //You can't have 2 ads at the same time ma man
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
       
          
        
    }
    public void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            MonoBehaviour.print("Interstitial is not ready yet");
        }
    }
}