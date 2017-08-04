using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseChar : MonoBehaviour
{
    [HideInInspector]
    public float selector;
    [HideInInspector]
    public int touchcount = 0;
    public bool isdestroying = false;
    public int themenumber;
    private void Awake()
    {
        themenumber = GameController.theme;
    }
    private void Start()
    {
        selector = Random.Range(1, 5);
    }
    private void FixedUpdate()
    {
        if (isdestroying)
        {
            this.gameObject.transform.localScale /= 1.02f;
        }
    }
    private void OnMouseDown()
    {
        if (touchcount == 0)
        {
            if (selector < 3)
            {
                this.transform.Find("JacketOpen").gameObject.SetActive(false);
                this.transform.Find("Innocent").gameObject.SetActive(true);
            }
            else if (selector >= 3)
            {
                this.transform.Find("JacketOpen").gameObject.SetActive(false);
                this.transform.Find("Criminal").gameObject.SetActive(true);
            }
            GroundScript.score++;
            touchcount++;
        }
        else
        {
            if(this.transform.Find("Innocent").gameObject.activeSelf)
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                disappear();
                GroundScript.score++;
            }
            if(this.transform.Find("Criminal").gameObject.activeSelf)
            {
                Instantiate(Resources.Load("GameOverImage"), GameObject.Find("BackgroundImage").transform);
                GroundScript.live = false;
                Handheld.Vibrate();
                Time.timeScale = 0;
            }
        }
    }
    void disappear()
    {
        GameObject parachute = Instantiate(Resources.Load(themenumber + "Parachute"), this.transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
        parachute.transform.SetParent(this.gameObject.transform);
        isdestroying = true;
        Destroy(this.gameObject, 0.5f);
    }
}
