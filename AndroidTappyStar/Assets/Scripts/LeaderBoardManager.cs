using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;


public class LeaderBoardManager : MonoBehaviour {

    public static LeaderBoardManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

	// Use this for initialization
	void Start () {
        PlayGamesPlatform.Activate();
        
        Login();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Login()
    {
        Social.localUser.Authenticate((bool success) => {
            if(!success)
            {
                
                Debug.Log("no success");
            }
            else
            {

            }
        });
    }

    public void AddScoreToLeaderBoard()
    {
        Social.ReportScore(ScoreManager.instance.getScore(), LeaderBoard.leaderboard_best_player, (bool success) => {

        });
    }

    public void ShowLeaderBoard()
    {
        if(Social.localUser.authenticated)
        { 
            PlayGamesPlatform.Instance.ShowLeaderboardUI(LeaderBoard.leaderboard_best_player);
            //Social.ShowLeaderboardUI();
        }
        else
        {
            Login();
        }
        
        //PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIjoH4w60KEAIQAA");
        //Social.ShowLeaderboardUI();
    }
}
