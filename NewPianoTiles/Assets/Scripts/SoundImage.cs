using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundImage : MonoBehaviour
{
    public Sprite SoundOnImage;
    public Sprite SoundOffImage;
    private void Start()
    {
        if (SoundToggle.mute == 1)
        { this.gameObject.GetComponent<SpriteRenderer>().sprite = SoundOffImage; }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = SoundOnImage;
        }
    }
    private void Update()
    {
        if(SoundToggle.mute==1)
        { this.gameObject.GetComponent<SpriteRenderer>().sprite = SoundOffImage; }
        else
        { this.gameObject.GetComponent<SpriteRenderer>().sprite = SoundOnImage; }
    }
}
