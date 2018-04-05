using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MenuUiManager : MonoBehaviour {

    public GameObject helpUsPanel;
    // Use this for initialization
    void Start () {
        //PlayGamesPlatform.Activate();
        LeaderBoardManager.instance.Login();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        SceneManager.LoadScene("level1");
    }

    public void HelpUsButtonClicked()
    {
        helpUsPanel.SetActive(true);
    }

    public void LaterButtonClicked()
    {
        helpUsPanel.SetActive(false);
    }

    public void WatchAdsButtonClicked()
    {
        HeyZapAdManager.instance.showHeyZapAds();
        //HeyZapAdManager.instance.showMediationTestSuite();
    }

    public void LeaderBoardButtonClicked()
    {
        LeaderBoardManager.instance.ShowLeaderBoard();
    }
}
