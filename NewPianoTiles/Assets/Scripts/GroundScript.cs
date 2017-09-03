﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundScript : MonoBehaviour
{
    public GameObject Ground;
    public GameObject image;
    public void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GreenTag")||other.CompareTag("BlueTag"))
        {
            UIManager.Instance.ShowGameOverMenu();
        }
        else
        {
            UIManager.Instance.score++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
