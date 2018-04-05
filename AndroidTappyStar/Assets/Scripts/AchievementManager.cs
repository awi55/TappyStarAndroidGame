using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour {

    public static AchievementManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

	// Use this for initial1ization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Login()
    {
        Social.localUser.Authenticate((bool success) => { });
    }

    public void ShowAchievements()
    {
        if(Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
        else
        {
            Login();
        }
    }

    public void CheckAchievements()
    {
        if (ScoreManager.instance.getScore() > 10)
        {
            Social.ReportProgress(Achievements.achievement_starter, 100f, (bool success) =>
            {
            });
        }

        if (ScoreManager.instance.getScore() > 30)
        {
            Social.ReportProgress(Achievements.achievement_intermediate, 100f, (bool success) =>
            {
            });
        }
        if (ScoreManager.instance.getScore() > 75)
        {
            Social.ReportProgress(Achievements.achievement_professional, 100f, (bool success) =>
            {
            });
        }
        
        if (ScoreManager.instance.getScore() > 125)
        {
            Social.ReportProgress(Achievements.achievement_expert, 100f, (bool success) =>
            {
            });
        }
        if (ScoreManager.instance.getScore() > 200)
        {
            Social.ReportProgress(Achievements.achievement_master, 100f, (bool success) =>
            {
            });
        }
    }
}
