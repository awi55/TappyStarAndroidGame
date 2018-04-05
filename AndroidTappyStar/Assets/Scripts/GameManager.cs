using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    //bool gameOver;
    int score;


    public float scrollSpeed = -1.5f;
    public bool gameOver;



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
    void Start()
    {
        gameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
       if(!gameOver)
        {
            AchievementManager.instance.CheckAchievements();
        }
    }

    public void GameStart()
    {
        UiManager.instance.GameStart();
       // GameObject.Find("StatueSpawner").GetComponent<StatueSpawner>().StartSpawningStatues();
        BackgroundMusicController.instance.PlayMusic();
        GameObject.Find("StatueSpawner").GetComponent<StatueSpawner>().StartSpawningStatues();
    }

    public void GameOver()
    {
        gameOver = false;
        GameObject.Find("StatueSpawner").GetComponent<StatueSpawner>().StopSpawningStatues();
        ScoreManager.instance.StopScore();
        UiManager.instance.GameOver();
        BackgroundMusicController.instance.StopMusic();
        LeaderBoardManager.instance.AddScoreToLeaderBoard();
        //UnityAdManager.instance.ShowAd();
        AdMobManager.instance.ShowInterstitial();
        

        //HeyzapAdManager.instance.showMediationTestSuite();
        //HeyzapAdManager.instance.showVideoAd();
        //HeyzapAdManager.instance.showRewardVideo();
        //HeyzapAdManager.instance.showInterstitialAd();
        //ChartBoostAdManager.instance.ShowInterstitialAd();
        //ChartBoostAdManager.instance.ShowRewardVideoAd();
        //ChartBoostAdManager.instance.ShowMoreApps();
    }
}
