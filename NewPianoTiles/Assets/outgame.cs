using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outgame : MonoBehaviour {

    private void OnMouseDown()
    {
        Destroy(this.gameObject);
    }
}
