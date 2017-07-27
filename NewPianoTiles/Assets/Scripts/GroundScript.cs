using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundScript : MonoBehaviour
{
    public static int score=0; 
    public GameObject Ground;
    public GameObject image;
    public Text Scoreboard;
    public static bool live = true;
    public void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        setScoreboard();   
    }
    private void Update()
    {
        setScoreboard();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("RedTag"))
        {
            Instantiate(Resources.Load("Gameoverimage"),GameObject.Find("BackgroundImage").transform);
            live = false;
            Handheld.Vibrate();
            Time.timeScale = 0;
        }
        else
        {
            score++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
    void setScoreboard()
    {
        Scoreboard.text = score.ToString();
    }
}
