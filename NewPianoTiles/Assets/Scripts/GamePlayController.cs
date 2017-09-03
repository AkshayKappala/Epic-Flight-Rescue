using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            case 1: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG1; break;
            case 2: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG2; break;
        }

    }
    private void Start()
    {
        UIManager.Instance.ScoreWallet.SetActive(true);
        UIManager.Instance.score = 0;
        UIManager.Instance.resume();
        Instantiate(Resources.Load(ThemeNumber + "RescueCharGreen"), new Vector3(0, 23.2f, 0), Quaternion.identity);
        StartCoroutine(storkcreation());
    }


    IEnumerator storkcreation()
    {
        yield return new WaitForSeconds(10 + Random.Range(0, 60));
        Instantiate(Resources.Load("Stork"), GameObject.Find("BackgroundImage").transform.position + new Vector3(10, Random.Range(-5, 5), 0), Quaternion.identity);
        StartCoroutine(storkcreation());
    }
}
