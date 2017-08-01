using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    public static int coins;
    public Text ShowCoins;
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        showcoins();
    }

    private void Update()
    {
        showcoins();
    }
    void showcoins()
    {
        ShowCoins.text = coins.ToString();
    }
}
