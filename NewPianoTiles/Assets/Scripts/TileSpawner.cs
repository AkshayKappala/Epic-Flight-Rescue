using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    private float positionselection, x,colorselection;
    private void OnTriggerExit(Collider other)
    {
     
            positionselection = Random.Range(1, 5);
            if (positionselection >= 1 && positionselection < 2)
                x = -4.07f;
            else if (positionselection >= 2 && positionselection < 3)
                x = -1.36f;
            else if (positionselection >= 3 && positionselection < 4)
                x = 1.36f;
            else
                x = 4.06f;

            colorselection = Random.Range(1, 11);
            if (colorselection >= 1 && colorselection < 2)
                Instantiate(Resources.Load("RescueCharRed"), new Vector3(x, 21.13f, 0), Quaternion.identity);
            if (colorselection >= 2 && colorselection < 8)
                Instantiate(Resources.Load("RescueCharGreen"), new Vector3(x, 21.13f, 0), Quaternion.identity);
            if (colorselection >= 8 && colorselection < 11)
                Instantiate(Resources.Load("RescueCharBlue"), new Vector3(x, 21.13f, 0), Quaternion.identity);
        }
}
