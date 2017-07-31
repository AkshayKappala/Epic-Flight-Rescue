using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int mute;

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
}
