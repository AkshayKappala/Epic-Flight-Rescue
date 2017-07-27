using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButtonScript : MonoBehaviour {

    private void OnMouseDown()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
        GroundScript.live = true;
    }
}
