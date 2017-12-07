﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftMovement : MonoBehaviour {
    public AudioClip clip;
    public AudioSource AudioSource;

    private void Start()
    {
        clip = Resources.Load("ParachuteOpen") as AudioClip;
        AudioSource = (AudioSource)FindObjectOfType<AudioSource>();
        AudioSource.loop = false;
    }
    void Update ()
    {
        transform.Translate(Vector2.down * Time.deltaTime * BasicTileScript.StartVelocity);
	}
    private void OnMouseDown()
    {
        AudioSource.PlayOneShot(clip);
        Instantiate(Resources.Load("PoofGold"), this.transform.position, Quaternion.identity);
        Economy.coins += 50;
        PlayerPrefs.SetInt("Coins", Economy.coins);
        Destroy(this.gameObject);
        //write coin increment code here
    }
}
