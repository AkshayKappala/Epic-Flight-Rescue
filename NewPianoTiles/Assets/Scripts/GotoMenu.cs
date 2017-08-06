using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMenu : MonoBehaviour
{
    public GameController gcscript;
    private void OnMouseDown()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        GroundScript.score = 0;
        Time.timeScale = 1.0f;
    }
}
