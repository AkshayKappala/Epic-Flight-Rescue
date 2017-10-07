using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    private void Update()
    {
        if (GameController.mute == 0)
            AudioListener.volume = 0;
        else
            AudioListener.volume = 1;
    }
}
