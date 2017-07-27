using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveScript : MonoBehaviour
{
    public GameObject Background;
    private void OnMouseDown()
    {
       // Destroy(this.transform.parent.gameObject);
        GroundScript.live = true;
        Time.timeScale = 1;
        Background = GameObject.Find("BackgroundImage");
        GameObject.Find("BackgroundImage").transform.Translate(Vector3.down * 5.5f);
        Destroy(this.transform.parent.gameObject);
    }
}