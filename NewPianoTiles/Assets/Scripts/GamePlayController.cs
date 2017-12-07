using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public int ThemeNumber;
    public GameObject BGMusic;
    public GameObject MainCamera;
    public GameObject Plane;
    public Sprite BG1;
    public Sprite BG2;
    public Sprite BG3;
    private void Awake()
    {
        SoundManagement();
        ThemeNumber = GameController.theme;
        switch (ThemeNumber)
        {
            case 1: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG1; break;
            case 2: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG2; break;
            case 3: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG3; break;
        }

    }

    public void SoundManagement()
    {
        MainCamera.GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("Soundpref");
        Plane.GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("Soundpref") * 0.6f;
        BGMusic.GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("Soundpref") * 0.6f;
    }
    public  void Start()
    {
        UIManager.Instance.LoadingScreen0.SetActive(false);
        SoundManagement();
        BGMusic.GetComponent<AudioSource>().PlayDelayed(2);
        UIManager.Instance.ScoreWallet.SetActive(true);
        UIManager.Instance.score = 0;
        UIManager.Instance.resume();
        Instantiate(Resources.Load(ThemeNumber + "RescueCharGreen"), new Vector3(0, 23.2f, 0), Quaternion.identity);
    }

}
