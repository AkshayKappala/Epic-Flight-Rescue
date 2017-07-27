using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GooglePlayGamesManager : MonoBehaviour {

    public Text Score;

    public void Awake()
    {
        IntiGooglePlayGames();
    }

    void Start()
    {
        if (!Social.localUser.authenticated)
        {
            SignInGooglePlay();
        }
    }

    public void IntiGooglePlayGames() {

        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    public void SignInGooglePlay() {

        Social.localUser.Authenticate((bool success) => {
            if (success) {
                // play services sign in successful
            }
            else {
                // unable to login to play services
            }
        });
    }

    public void PostScoreToLB()
    {

        if (Social.localUser.authenticated)
        {
            PostScore();
        }
        else
        {
            // user not logged in to play services
        }
    }

    public void PostScore() {
        Social.ReportScore(int.Parse(Score.text), "CgkIpeiRn58REAIQAQ", (bool success) => {
            // handle success or failure
            if (success) {
                // score updated to LB
            } else {
                // score not updated
            }
        });

    }

    public void ShowLBUI() {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIpeiRn58REAIQAQ");
        }
        else
        {
            // user not logged in to play services
        }
    }
}
