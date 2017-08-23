using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public int themenumber;
    [HideInInspector]
    public GameObject tempChar;
    private void Awake()
    {
        themenumber = GameController.theme;
    }

    private float positionselection, x,colorselection;
    private void OnTriggerExit(Collider other)
    {
     
            positionselection = Random.Range(1, 6);
        if (positionselection >= 1 && positionselection < 2)
            x = -4;
        else if (positionselection >= 2 && positionselection < 3)
            x = -2;
        else if (positionselection >= 3 && positionselection < 4)
            x = 0;
        else if (positionselection >= 4 && positionselection < 5)
            x = 2;
        else
            x = 4;

            colorselection = Random.Range(10, 192);
        if (colorselection >= 10 && colorselection < 20)
            tempChar = Instantiate(Resources.Load(themenumber + "RescueCharRed"), GameObject.Find("BackgroundImage").transform.position + new Vector3(x, 21.13f, 0), Quaternion.identity) as GameObject;
        else if (colorselection >= 20 && colorselection < 80)
            tempChar = Instantiate(Resources.Load(themenumber + "RescueCharGreen"), GameObject.Find("BackgroundImage").transform.position + new Vector3(x, 21.13f, 0), Quaternion.identity) as GameObject;
        else if (colorselection >= 80 && colorselection < 110)
            tempChar = Instantiate(Resources.Load(themenumber + "RescueCharBlue"), GameObject.Find("BackgroundImage").transform.position + new Vector3(x, 21.13f, 0), Quaternion.identity) as GameObject;
        // else (colorselection >= 110)
        else if (colorselection >= 110 && colorselection < 130)
            tempChar = Instantiate(Resources.Load(themenumber + "SurpriseChar"), GameObject.Find("BackgroundImage").transform.position + new Vector3(x, 21.13f, 0), Quaternion.identity) as GameObject;
        else if (colorselection >= 130 && colorselection < 133)
            tempChar = Instantiate(Resources.Load(themenumber + "Gift"), GameObject.Find("BackgroundImage").transform.position + new Vector3(x, 21.13f, 0), Quaternion.identity) as GameObject;
        else
            tempChar = Instantiate(Resources.Load(themenumber + "RescueCharGreenF"), GameObject.Find("BackgroundImage").transform.position + new Vector3(x, 21.13f, 0), Quaternion.identity) as GameObject;
        other.gameObject.layer = 13;
        }
}
