using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public int ThemeNumber;
    private void Start()
    {
        ThemeNumber = GameController.theme;
        Instantiate(Resources.Load(ThemeNumber+"RescueCharGreen"), new Vector3(0, 23.2f, 0), Quaternion.identity);
    }
   /* public void AdNRevive()
    {
        GroundScript.live = true;
        Time.timeScale = 1;
        GameObject.Find("BackgroundImage").transform.Translate(Vector3.down * 5.5f);
        //Destroy(GameObject.Find("GameOverImage(Clone)"));
        Destroy(GameObject.Find("GameoverReference").GetComponentInChildren<Transform>().gameObject);
    }*/
}
