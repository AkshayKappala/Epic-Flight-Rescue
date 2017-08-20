using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public int ThemeNumber;
    public Sprite BG1;
    public Sprite BG2;
    public GameObject PauseMenu;
    public GameObject PauseButton;
    private void Awake()
    {
        ThemeNumber = GameController.theme;
        switch (ThemeNumber)
        {
            case 1: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG1;break;
            case 2: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG2; break;
        }
        PauseMenu = GameObject.Find("PauseMenu");
        PauseMenu.SetActive(false);
        PauseButton = GameObject.Find("Pause");
       // GameObject.Find("PauseMenu").SetActive(false);
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
        Instantiate(Resources.Load("Stork"),GameObject.Find("BackgroundImage").transform.position + new Vector3(10,Random.Range(-5,5), 0), Quaternion.identity);
        StartCoroutine(storkcreation());
    }
    public void pause()
    {
        if (!GameObject.Find("GameOverImage(Clone)"))
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            PauseButton.SetActive(false);
        }
    }

    public void resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        PauseButton.SetActive(true);
    }

    public void gotomenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        GroundScript.score = 0;
        Time.timeScale = 1.0f;
    }
}
