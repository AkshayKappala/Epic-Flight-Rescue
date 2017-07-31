using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemePrevious : MonoBehaviour {

    private void OnMouseDown()
    {
        if(GameController.theme==2)
        {
            GameController.theme = 1;
        }
    }
}
