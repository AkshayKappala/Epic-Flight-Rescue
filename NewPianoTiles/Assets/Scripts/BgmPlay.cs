using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmPlay : MonoBehaviour {

    private void Start()
    {
        if (SoundToggle.mute == 0)
        {
            this.gameObject.GetComponent<AudioSource>().PlayDelayed(2);
        }
    }
}
