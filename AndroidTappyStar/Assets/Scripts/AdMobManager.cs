using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobManager : MonoBehaviour {

    InterstitialAd interstitial;
    BannerView bannerView;
    public static AdMobManager instance;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        RequestInterstitial();
        RequestBanner();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-0793283496719692/9156872129";
        #elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
        #else
        string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    private void RequestBanner()
    {
        #if UNITY_EDITOR
        string adUnitId = "unused";
        #elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-0793283496719692/8183358345";
        #elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
        #else
        string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.BottomLeft);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    //ca-app-pub-0793283496719692/8183358345

    public void ShowInterstitial()
    {
        if (PlayerPrefs.HasKey("AdMobcount"))
        {
            if (PlayerPrefs.GetInt("AdMobcount") == 5)
            {
                if (interstitial.IsLoaded())
                {
                    interstitial.Show();
                }
                PlayerPrefs.SetInt("AdMobcount", 0);
            }
            else
            {
                PlayerPrefs.SetInt("AdMobcount", PlayerPrefs.GetInt("AdMobcount") + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("AdMobcount", 0);
        }
    }

    public void ShowBanner()
    {
        bannerView.Show();
    }
}
