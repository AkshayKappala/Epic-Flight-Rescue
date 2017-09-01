using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartScript : MonoBehaviour {
    private void OnMouseDown()
    {
        SceneManager.LoadScene("GamePlay",LoadSceneMode.Single);
        GroundScript.score = 0;
        GroundScript.live = true;

        Time.timeScale = 1.0f;
    }
    public void Restart()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
        GroundScript.score = 0;
        GroundScript.live = true;

        Time.timeScale = 1.0f;
    }
}
