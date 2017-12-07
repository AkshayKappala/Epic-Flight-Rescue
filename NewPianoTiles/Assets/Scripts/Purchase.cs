using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Khadga.Yodha.Prasanth;

public class Purchase : MonoBehaviour {
    public GameObject ThemeLocker;
    public AudioClip clip;
    public AudioSource AudioSource;
    // Use this for initialization
    void Start () {
        clip = Resources.Load("ParachuteOpen") as AudioClip;
        AudioSource = (AudioSource)FindObjectOfType<AudioSource>();
        AudioSource.loop = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuyAllCharcs()
    {
        // IAPManager.instance.UnlockAll();
        AudioSource.PlayOneShot(clip);
        PlayerPrefs.SetInt("isUnlocked", 5);
        ThemeLocker.SetActive(false);
    }

}
