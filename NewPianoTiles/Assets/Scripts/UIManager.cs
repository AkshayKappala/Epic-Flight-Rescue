using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject GameOverMenu;
    public GameObject ScoreWallet;
    public GameObject GameOverLayer;
    public GameObject NoCoins;
    public int score = 0;
    public Text Scoreboard;
    public int HighScore;
    public Text SetHighScore;

    void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        HighScore = PlayerPrefs.GetInt("HighScore");
        sethighscore();

    }

    private void Start()
    {
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        GameOverLayer.SetActive(false);
        setScoreboard();
        SetHighScore.text = "High Score : " + HighScore.ToString();
    }

    private void Update()
    {
        setScoreboard();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!PauseMenu.activeSelf)
            {
                Pause();
            }
        }
    }

    public void ShowGameOverMenu()
    {
        PauseButton.SetActive(false);
        PauseMenu.SetActive(false);
        NoCoins.SetActive(false);
        sethighscore();
        Time.timeScale = 0;
        GameOverLayer.SetActive(true);
        StartCoroutine(ShowGameOverMenuIE());
    }

    public void CloseGameOverMenu()
    {
        NoCoins.SetActive(false);
        PauseButton.SetActive(true);
        GameOverMenu.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(CloseGameOverLayer());
    }

    public void Pause()
    {
        if (!GameOverMenu.activeSelf)
        {
           
            Time.timeScale = 0;
            PauseButton.SetActive(false);
            PauseMenu.SetActive(true);
            GameOverLayer.SetActive(true);
        }
    }

    public void resume()
    {
      //  GameObject.Find("BackgroundImage").transform.Translate(Vector3.down * 5.5f);
        GameObject.Find("BackgroundImage").transform.Translate(Vector3.down * BasicTileScript.StartVelocity * 2);
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(CloseGameOverLayer());
    }

    public void gotomenu()
    {
        resume();
        /*PauseButton.SetActive(false);
        PauseMenu.SetActive(false);*/
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(false);
        PauseButton.SetActive(false);
        Scoreboard.text = null;
        sethighscore();
    }

    public void Revive()
    {
        if (Economy.coins >= 200)
        {
            Economy.coins -= 200;
            PlayerPrefs.SetInt("Coins", Economy.coins);
            CloseGameOverMenu();
            GameObject.Find("BackgroundImage").transform.Translate(Vector3.down * BasicTileScript.StartVelocity * 2);
        }

        else
        {
            NoCoins.SetActive(true);
        }
    }

    public void AdnRevive()
    {
        Economy.coins += 100;
        PlayerPrefs.SetInt("Coins", Economy.coins);
        CloseGameOverMenu();
        GameObject.Find("BackgroundImage").transform.Translate(Vector3.down * BasicTileScript.StartVelocity * 2);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
        CloseGameOverMenu();
    }

    void setScoreboard()
    {
        Scoreboard.text = score.ToString();
    }

    void sethighscore()
    {
       // if (SetHighScore != null)
       if(score>=PlayerPrefs.GetInt("HighScore"))
        {
            HighScore = score;
            PlayerPrefs.SetInt("HighScore", HighScore);
            SetHighScore.text = "High Score : " + HighScore.ToString();
        }
    }

    IEnumerator CloseGameOverLayer()
    {
        yield return new WaitForSeconds(0.1f);
        GameOverLayer.SetActive(false);
    }

    IEnumerator ShowGameOverMenuIE()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        GameOverMenu.SetActive(true);
    }

    public void OnApplicationPause(bool pause)
    {
        Pause();
    }
    public void OnApplicationFocus(bool focus)
    {
        if(SceneManager.GetActiveScene().name!="Gameplay")
        {
            resume();
        }
    }
}