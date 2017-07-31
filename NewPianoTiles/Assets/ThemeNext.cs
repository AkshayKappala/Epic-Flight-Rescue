using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeNext : MonoBehaviour {

    private void OnMouseDown()
    {
        if(GameController.theme==1)
        {
            GameController.theme = 2;
        }
    }
}
