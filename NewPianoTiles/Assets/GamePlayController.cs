using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public int ThemeNumber;
    public Sprite BG1;
    public Sprite BG2;
    private void Awake()
    {
        ThemeNumber = GameController.theme;
        switch (ThemeNumber)
        {
            case 1: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG1;break;
            case 2: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG2; break;
        }
    }
    private void Start()
    {
        Instantiate(Resources.Load(ThemeNumber+"RescueCharGreen"), new Vector3(0, 23.2f, 0), Quaternion.identity);
        StartCoroutine(storkcreation());
    }
   /* public void AdNRevive()
    {
        GroundScript.live = true;
        Time.timeScale = 1;
        GameObject.Find("BackgroundImage").transform.Translate(Vector3.down * 5.5f);
        //Destroy(GameObject.Find("GameOverImage(Clone)"));
        Destroy(GameObject.Find("GameoverReference").GetComponentInChildren<Transform>().gameObject);
    }*/
    IEnumerator storkcreation()
    {
        yield return new WaitForSeconds(10+Random.Range(0,60));
        Instantiate(Resources.Load("Stork"), new Vector3(10,Random.Range(-5,5), 0), Quaternion.identity);
        StartCoroutine(storkcreation());
    }
}
