using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    public GameObject PlaneSound;
    private void Update()
    {

        if (GameController.mute == 0)
            AudioListener.volume = 1;
        else
            AudioListener.volume = 0;
    }
}
