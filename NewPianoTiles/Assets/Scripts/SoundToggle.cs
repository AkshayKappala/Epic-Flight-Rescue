using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    public Sprite SoundOnImage;
    public Sprite SoundOffImage;
    public static int mute;
      private void Start()
      {
          mute = PlayerPrefs.GetInt("SoundPref");
         
      }
     
    private void Update()
    {
        PlayerPrefs.SetInt("Soundpref", mute);
        if (mute == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = SoundOnImage;
        }
        else if (mute == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = SoundOffImage;
        }

    }
    private void OnMouseDown()
    {
        if (mute == 0)
        {
            mute = 1;
        }
        else if (mute == 1)
        {
            mute = 0;
        }
    }
}
