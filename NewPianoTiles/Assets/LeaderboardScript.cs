using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardScript : MonoBehaviour {

    public GameObject GooglePlayManager;

    private void OnMouseDown()
    {
        GooglePlayManager.GetComponent<GooglePlayGamesManager>().ShowLBUI();
    }
}
