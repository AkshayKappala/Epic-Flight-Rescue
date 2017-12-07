﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;

public class GameController : MonoBehaviour
{
    public static int mute;
    public static int theme;
    public float PopupMaxTime;
    public float PopupStartTime;

    public GameObject MainCamera;
    public GameObject ThemeLocker;
    public GameObject shop;
    public GameObject DevopTools;
    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
    public GameObject LoadingScreen;
    public GameObject Sound_CrossMark;

    public GameObject PlayButton;
    public GameObject ShopButton;
    public GameObject HelpButton;
    public GameObject RankButton;
    public GameObject ShareButton;
    public GameObject SoundButton;


    public Text MMHighScore;
    private int tap;
    private bool readyForDoubleTap;
    private int themeNumberBuffer;
    string subject = "Subject text";
    string body = "Actual text (Link)";

    private void Awake()
    {
        PopupMaxTime = 100;
        if(Time.realtimeSinceStartup<5)
            SetPopupInitialScales();
        theme = PlayerPrefs.GetInt("Theme");
        mute = PlayerPrefs.GetInt("Soundpref");
        MainCamera.GetComponent<AudioSource>().volume = mute;
        if (theme != 1 && theme != 2 && theme != 3)
        {
            theme = 2;
        }
    }
    private void Start()
    {

        if(UIManager.Instance)
            UIManager.Instance.LoadingScreen0.SetActive(false);
        LoadingScreen.SetActive(false);
        if (GameObject.Find("UIManager"))
            UIManager.Instance.ScoreWallet.SetActive(false);
        // GameObject.Find("PauseMenu").SetActive(false);
        // GameObject.Find("PauseButton").SetActive(false);
        PopupStartTime = Time.realtimeSinceStartup;
        mute = PlayerPrefs.GetInt("Soundpref");
        MainCamera.GetComponent<AudioSource>().volume = mute;
        SoundIconChanger();
        ThemeLock();

       /* if (PlayerPrefs.GetInt("HighScore") == 0)
        {
            //write tutorial method here
            TutorialCall();
        }*/
        MMHighScore.text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
        if(Time.realtimeSinceStartup<5)
            IconsPop();
    }

    private void FixedUpdate()
    {
        if (Time.realtimeSinceStartup < PopupMaxTime)
            UIButtonPopAnimations(Time.realtimeSinceStartup);
    }

    public void SetPopupInitialScales()
    {
        PlayButton.GetComponent<Animator>().enabled = false;
        ShopButton.GetComponent<Animator>().enabled = false;
        HelpButton.GetComponent<Animator>().enabled = false;
        ShareButton.GetComponent<Animator>().enabled = false;
        SoundButton.GetComponent<Animator>().enabled = false;
        RankButton.GetComponent<Animator>().enabled = false;
        PlayButton.transform.localScale = new Vector3(0, 0, 0);
        ShopButton.transform.localScale = new Vector3(0, 0, 0);
        HelpButton.transform.localScale = new Vector3(0, 0, 0);
        ShareButton.transform.localScale = new Vector3(0, 0, 0);
        SoundButton.transform.localScale = new Vector3(0, 0, 0);
        RankButton.transform.localScale = new Vector3(0, 0, 0);
    }


    public void IconsPop()
    {
        GameObject.Find("ButtonPlay").GetComponent<Animator>().Play("ButtonPlaypop");
        GameObject.Find("GooglePlay").GetComponent<Animator>().Play("googleplaypop");
        GameObject.Find("ShopButton").GetComponent<Animator>().Play("shopbuttonpop");
        GameObject.Find("SoundIcon").GetComponent<Animator>().Play("soundiconpop");
        GameObject.Find("HelpButton").GetComponent<Animator>().Play("helpbuttonpop");
        GameObject.Find("ShareButton").GetComponent<Animator>().Play("sharebuttonpop");
    }


    public void ThemeLock()
    {
        if (PlayerPrefs.GetInt("isUnlocked") == 5)
        {
            ThemeLocker.SetActive(false);
        }
    }

    public void Play()
    {

        if (PlayerPrefs.GetInt("HighScore") == 0)
        {
            TutorialCall();
        }
        else
        {
            LoadingScreen.SetActive(true);
            SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
        }
    }

    public void SoundToggle()
    {

        if (mute == 0)
        {
            mute = 1;
        }
        else
        {
            mute = 0;
        }
        PlayerPrefs.SetInt("Soundpref", mute);
        MainCamera.GetComponent<AudioSource>().volume = mute;
        SoundIconChanger();
    }

    public void SoundIconChanger()
    {
        if (mute == 1)
        {
            Sound_CrossMark.SetActive(false);
        }
        else
        {
            Sound_CrossMark.SetActive(true);
        }
    }

    public void Theme1()
    {
        theme = 1;
        SaveTheme(1);
        Double_click_play(1);
    }
    public void Theme2()
    {
        theme = 2;
        SaveTheme(2);
        Double_click_play(2);
    }
    public void Theme3()
    {
        theme = 3;
        SaveTheme(3);
        Double_click_play(3);
    }
    public void SaveTheme(int n)
    {
        PlayerPrefs.SetInt("Theme", n);
    }

    public void Double_click_play(int theme_number)
    {
        tap++;

        if (tap == 1)
        {
        
            themeNumberBuffer = theme_number;
            readyForDoubleTap = true;
            StartCoroutine(DoubleTapInterval());
        }

        else if (tap > 1 && readyForDoubleTap && themeNumberBuffer==theme_number)
        {
           
            Play();

            tap = 0;
            readyForDoubleTap = false;
        }
        else
        {
            tap = 0;
            readyForDoubleTap = false;
        }
    }

    IEnumerator DoubleTapInterval()
    {
        yield return new WaitForSeconds(0.5f);
        readyForDoubleTap = false;
    }


    public void ShopButtonClick()
    {
        shop.SetActive(true);
    }

    public void ShopCloseButton()
    {
        shop.GetComponent<Animator>().Play("ShopClose");
        StartCoroutine(ShopClose());
      //  shop.SetActive(false);
    }

    public void DevopToolsButton()
    {
        DevopTools.SetActive(true);
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    public void DevopToolsClose()
    {
        DevopTools.SetActive(false);
    }

    public void WatchAd()
    {
        Economy.coins += 100;
        PlayerPrefs.SetInt("Coins", Economy.coins);
    }

    /*public void ShopPurchase1()
    {
        if (Economy.coins >= 200)
        {
            Economy.coins -= 200;
        }
    }*/


    IEnumerator ShopClose()
    {
        yield return new WaitForSecondsRealtime(0.15f);
        shop.SetActive(false);
    }

    public void TutorialCall()
    {
        if (!Tutorial1.activeSelf && !Tutorial2.activeSelf && !Tutorial3.activeSelf)
        {
            Tutorial1.SetActive(true);
            GameObject.Find("TutorialImage1").SetActive(true);
        }
        else if (Tutorial1.activeSelf && !Tutorial2.activeSelf && !Tutorial3.activeSelf)
        {
            Tutorial1.SetActive(false);
            Tutorial2.SetActive(true);
        }
        else if (!Tutorial1.activeSelf && Tutorial2.activeSelf && !Tutorial3.activeSelf)
        {
            Tutorial2.SetActive(false);
            Tutorial3.SetActive(true);
        }
        else if (!Tutorial1.activeSelf && !Tutorial2.activeSelf && Tutorial3.activeSelf)
        {
            Tutorial3.SetActive(false);
            LoadingScreen.SetActive(true);
            //play code here
            SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
        }
    }


    public void UIButtonPopAnimations(float currentTime)
    {

        

        if(currentTime>=PopupStartTime&&currentTime<=PopupStartTime+0.2f)
        {
            PlayButton.transform.localScale = new Vector3(2,2, 1) + (new Vector3(1, 1, 0) * (currentTime -PopupStartTime)*2.5f);
        }
        else if(currentTime>=PopupStartTime+0.2f && currentTime<=PopupStartTime+0.4f)
        {
            ShopButton.transform.localScale = new Vector3(0.8f, 0.8f, 1) + (new Vector3(1, 1, 0) * (currentTime - PopupStartTime-0.2f) *2.5f);
        }
        else if(currentTime>=PopupStartTime+0.4f && currentTime<=PopupStartTime+0.6f)
        {
            HelpButton.transform.localScale = new Vector3(0.5f, 0.5f, 1) + (new Vector3(1, 1, 0) * (currentTime - PopupStartTime-0.4f) *2.5f);
        }
        else if (currentTime >= PopupStartTime+0.6f && currentTime <= PopupStartTime+0.8f)
        {
            RankButton.transform.localScale = new Vector3(0.8f, 0.8f, 1) + (new Vector3(1, 1, 0) * (currentTime - PopupStartTime-0.6f) *2.5f);
        }
        else if (currentTime >= PopupStartTime+0.8f && currentTime <= PopupStartTime+1.0f)
        {
            ShareButton.transform.localScale = new Vector3(0.8f, 0.8f, 1) + (new Vector3(1, 1, 0) * (currentTime - PopupStartTime-0.8f) *2.5f);
        }
        else if (currentTime >= PopupStartTime+1.0f && currentTime <= PopupStartTime+1.2f)
        {
            SoundButton.transform.localScale = new Vector3(0.5f, 0.5f, 1) + (new Vector3(1, 1, 0) * (currentTime - PopupStartTime-1.0f) *2.5f);
        }


        if(Time.realtimeSinceStartup>PopupStartTime+1.2f)
        {
            PlayButton.GetComponent<Animator>().enabled = true;
            ShopButton.GetComponent<Animator>().enabled = true;
            HelpButton.GetComponent<Animator>().enabled = true;
            ShareButton.GetComponent<Animator>().enabled = true;
            SoundButton.GetComponent<Animator>().enabled = true;
            RankButton.GetComponent<Animator>().enabled = true;
        }


    }


    //RATE AND SHARE CODE FROM HERE(DUMPED FROM NET)

#if UNITY_IPHONE
	
	[DllImport("__Internal")]
	private static extern void sampleMethod (string iosPath, string message);
	
	[DllImport("__Internal")]
	private static extern void sampleTextMethod (string message);
	
#endif

    public void OnAndroidTextSharingClick()
    {

        StartCoroutine(ShareAndroidText());

    }
    IEnumerator ShareAndroidText()
    {
        yield return new WaitForEndOfFrame();
        //execute the below lines if being run on a Android device
#if UNITY_ANDROID
        //Reference of AndroidJavaClass class for intent
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        //Reference of AndroidJavaObject class for intent
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
        //call setAction method of the Intent object created
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        //set the type of sharing that is happening
        intentObject.Call<AndroidJavaObject>("setType", "text/plain");
        //add data to be passed to the other activity i.e., the data to be sent
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
        //intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TITLE"), "Text Sharing ");
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
        //get the current activity
        AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
        //start the activity by sending the intent data
        AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via");
        currentActivity.Call("startActivity", jChooser);
#endif
    }


    public void OniOSTextSharingClick()
    {

#if UNITY_IPHONE || UNITY_IPAD
		string shareMessage = "Wow I Just Share Text ";
		sampleTextMethod (shareMessage);
		
#endif
    }

    public void RateUs()
    {
#if UNITY_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.freakspace.perfectturn&hl=en");
#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
#endif
    }

}
