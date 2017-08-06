using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;

public class GameController : MonoBehaviour
{
    public static int mute;
    public static int theme=1;
    public GameObject shop;
    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
    string subject = "Subject text";
    string body = "Actual text (Link)";

    private void Awake()
    {
        mute = PlayerPrefs.GetInt("Soundpref");
    }
    private void Start()
    {
        if (mute == 0)
        {
            GameObject.Find("SoundToggle").GetComponent<Toggle>().isOn = true;
        }
        else if (mute == 1)
        {
            GameObject.Find("SoundToggle").GetComponent<Toggle>().isOn = false;
        }
        if (HighScoreUpdater.HighScore == 0)
        {
            //write tutorial method here
            TutorialCall();
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
        GroundScript.live = true;
    }

    public void SoundToggle()
    {
        
        if (mute == 0)
        {
            mute = 1;
        }
        else if(mute==1)
        {
            mute = 0;
        }
        PlayerPrefs.SetInt("Soundpref", mute); 
    }

    public void ThemeNext()
    {
        if (theme == 1)
            theme = 2;
    }
    public void ThemePrevious()
    {
        if (theme == 2)
            theme = 1;
    }

    public void ShopButtonClick()
    {
        //GameObject.Find("Shop").SetActive(true);
        shop.SetActive(true);
    }

    public void ShopCloseButton()
    {
        //GameObject.Find("Shop").SetActive(false);
        shop.SetActive(false);
    }

    public void WatchAd()
    {
        Economy.coins += 100;
        PlayerPrefs.SetInt("Coins", Economy.coins);
    }

    public void ShopPurchase1()
    {
        if (Economy.coins >= 200)
        {
            Economy.coins -= 200;
        }
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
