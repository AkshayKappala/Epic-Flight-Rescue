using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public int ThemeNumber;
    public GameObject BGMusic;
    public GameObject Sound_Listener;
    public Sprite BG1;
    public Sprite BG2;
    public Sprite BG3;
    private void Awake()
    {
        ThemeNumber = GameController.theme;
        switch (ThemeNumber)
        {
            case 1: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG1; break;
            case 2: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG2; break;
            case 3: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG3; break;
        }

    }

    public void SoundListenToggle()
    {
       /* if(PlayerPrefs.GetInt("Soundpref")==0)
        {
            Sound_Listener.SetActive(true);
        }
        else
        {
            Sound_Listener.SetActive(false);
        }*/
    }

    private void Start()
    {
        SoundListenToggle();
        BGMusic.GetComponent<AudioSource>().PlayDelayed(2);
        UIManager.Instance.ScoreWallet.SetActive(true);
        UIManager.Instance.score = 0;
        UIManager.Instance.resume();
        Instantiate(Resources.Load(ThemeNumber + "RescueCharGreen"), new Vector3(0, 23.2f, 0), Quaternion.identity);
    }

}
