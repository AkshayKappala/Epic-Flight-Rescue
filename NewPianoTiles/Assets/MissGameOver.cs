using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissGameOver : MonoBehaviour {
    private void OnMouseDown()
    {
        
        Instantiate(Resources.Load("GameOverImage"), GameObject.Find("BackgroundImage").transform);
        GroundScript.live = false;
        Handheld.Vibrate();
        Time.timeScale = 0;
    }

}
