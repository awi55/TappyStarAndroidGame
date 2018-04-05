using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Heyzap;

public class HeyZapAdManager : MonoBehaviour
{
    public static HeyZapAdManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Use this for initialization
    void Start()
    {
        HeyzapAds.Start("ecef46611330f64b1c88df6f89c05b63", HeyzapAds.FLAG_NO_OPTIONS);
        HZVideoAd.Fetch();
        HZIncentivizedAd.Fetch();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showInterstitialAd()
    {
        HZInterstitialAd.Show();
    }

    public void showVideoAd()
    {
        if (HZVideoAd.IsAvailable())
        {
            HZVideoAd.Show();
        }
    }

    public void showRewardVideo()
    {
        if (HZIncentivizedAd.IsAvailable())
        {
            HZIncentivizedAd.Show();
        }
    }

    public void showMediationTestSuite()
    {
        HeyzapAds.ShowMediationTestSuite();
    }

    public void showHeyZapAds()
    {
        if (PlayerPrefs.HasKey("HeyZadAdcount"))
        {
            if (PlayerPrefs.GetInt("HeyZadAdcount") == 3)
            {
                HZInterstitialAd.Show();
                PlayerPrefs.SetInt("HeyZadAdcount", 0);
            }
            else
            {
                if (HZVideoAd.IsAvailable())
                {
                    HZVideoAd.Show();
                }
                PlayerPrefs.SetInt("HeyZadAdcount", PlayerPrefs.GetInt("HeyZadAdcount") + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HeyZadAdcount", 0);
        }
    }
}
