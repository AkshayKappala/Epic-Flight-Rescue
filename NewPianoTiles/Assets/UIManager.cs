using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject GameOverMenu;

    void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ShowGameOverMenu()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseGameOverMenu()
    {
        GameOverMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
