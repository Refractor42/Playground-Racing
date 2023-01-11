using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds;
public class AdMobManager : MonoBehaviour
{



    

    public void Start()
    {


        MobileAds.Initialize(appID);

    }
    private BannerView bannerView;
    [SerializeField] private string appID = "ca-app-pub-5174796967747907~9932595147";
    [SerializeField] private string bannerID = "ca-app-pub-3940256099942544/6300978111";
    [SerializeField] private string regularAD = "ca-app-pub-3940256099942544/1033173712";
   
public void OnClickShowBanner()
    {
       
        AdSize adSize = new AdSize(250, 250);
        BannerView bannerView = new BannerView(bannerID, AdSize.Banner, 0, 50);
        this.RequestBanner();

    }
    public void OnClickShowAd()
    {
        InterstitialAd AD = new InterstitialAd(regularAD);
        AdRequest request = new AdRequest.Builder().Build();
        AD.LoadAd(request);

    }
    private void RequestBanner()
    {
        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);

    }
}
