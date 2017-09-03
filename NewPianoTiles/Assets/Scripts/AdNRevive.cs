using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdNRevive : MonoBehaviour
{
    private void OnMouseDown()
    {
        watchAd();
        UIManager.Instance.pause();
        Time.timeScale = 1;
        GameObject.Find("BackgroundImage").transform.Translate(Vector3.down * 5.5f);
        Destroy(this.transform.parent.gameObject);
    }
    public void watchAd()
    {
        Economy.coins += 100;
        PlayerPrefs.SetInt("Coins", Economy.coins);
    }
}