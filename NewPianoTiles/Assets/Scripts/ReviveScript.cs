using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        GroundScript.live = true;
        Time.timeScale = 1;
        GameObject.Find("BackgroundImage").transform.Translate(Vector3.down *BasicTileScript.StartVelocity*2);
        Destroy(this.transform.parent.gameObject);
    }
}