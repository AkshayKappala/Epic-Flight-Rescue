using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUpdater : MonoBehaviour {
    public static int HighScore;
    public Text SetHighScore;
	void Start ()
    {
        HighScore=PlayerPrefs.GetInt("HighScore");
        sethighscore();
    }

	void Update ()
    {
        if(GroundScript.score>=HighScore)
        {
            HighScore = GroundScript.score;
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
        sethighscore();
	}
    void sethighscore()
    {
        SetHighScore.text = "High Score : "+ HighScore.ToString();
    }
}
