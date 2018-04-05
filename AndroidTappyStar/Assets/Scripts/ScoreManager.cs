using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    int score;
    private int myScore;
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
        score = 0;
        myScore = score;
        PlayerPrefs.SetInt("Score", 0);
    }

    public int getScore()
    {
        return myScore;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IncrementScore()
    {
        score++;
        myScore = score;
    }

    public void StopScore()
    {
        PlayerPrefs.SetInt("Score", score);

        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
