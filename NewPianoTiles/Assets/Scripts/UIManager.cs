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
        setScoreboard();
    }

    private void Update()
    {
        setScoreboard();
    }

    public void ShowGameOverMenu()
    {
        sethighscore();
        GameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseGameOverMenu()
    {
        GameOverMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void pause()
    {
        if (!GameOverMenu.activeSelf)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            PauseButton.SetActive(false);
        }
    }

    public void resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        PauseButton.SetActive(true);
    }

    public void gotomenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
        PauseButton.SetActive(false);
        GameOverMenu.SetActive(false);
        Scoreboard.text = null;
        sethighscore();
    }

    public void Revive()
    {
        CloseGameOverMenu();
        GameObject.Find("BackgroundImage").transform.Translate(Vector3.down * BasicTileScript.StartVelocity * 2);
    }

    public void AdnRevive()
    {
        Economy.coins += 100;
        PlayerPrefs.SetInt("Coins", Economy.coins);
        CloseGameOverMenu();
        GameObject.Find("BackgroundImage").transform.Translate(Vector3.down * 5.5f);
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
}
