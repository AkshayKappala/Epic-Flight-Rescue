using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Sound1;

    public void PlaySound1()
    {
        Source.clip = Sound1;
        Source.Play();
    }

}
