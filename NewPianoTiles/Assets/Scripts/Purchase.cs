using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Khadga.Yodha.Prasanth;

public class Purchase : MonoBehaviour {
    public GameObject ThemeLocker;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuyAllCharcs()
    {
        IAPManager.instance.UnlockAll();
        PlayerPrefs.SetInt("isUnlocked", 5);
        ThemeLocker.SetActive(false);
    }

}
