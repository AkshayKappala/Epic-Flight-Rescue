using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseChar : MonoBehaviour
{
    public bool isfirsttap = false;
    public static float StartVelocity;
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
        StartVelocity = 7;
        selector = Random.Range(1, 5);
    }
    void Update()
    {
        StartVelocity = 7 + 0.01f * GroundScript.score;
        transform.Translate(Vector3.down * Time.deltaTime * StartVelocity);
        if (GroundScript.live == false || isfirsttap == true)
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        else if (GroundScript.live == true)
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
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
                
                disappear();
                GroundScript.score++;
                isfirsttap = true;
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
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        isdestroying = true;
        Destroy(this.gameObject, 0.5f);
    }
}
