using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
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

            colorselection = Random.Range(1, 11);
            if (colorselection >= 1 && colorselection < 2)
                Instantiate(Resources.Load("RescueCharRed"), new Vector3(x, 21.13f, 0), Quaternion.identity);
            if (colorselection >= 2 && colorselection < 8)
                Instantiate(Resources.Load("RescueCharGreen"), new Vector3(x, 21.13f, 0), Quaternion.identity);
            if (colorselection >= 8 && colorselection < 11)
                Instantiate(Resources.Load("RescueCharBlue"), new Vector3(x, 21.13f, 0), Quaternion.identity);
        }
}
