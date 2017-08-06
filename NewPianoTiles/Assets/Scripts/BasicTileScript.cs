using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicTileScript : MonoBehaviour
{
    public static float StartVelocity;
    //[HideInInspector]
    //public GameObject greener;
    public bool isdestroying = false;
    [HideInInspector]
    public bool isfirsttap=false;
    public TileType Tiletype;
    private AudioClip clip;
    [HideInInspector]
    public int tapCount=0;
    public int themenumber;
    private void Awake()
    {
        themenumber = GameController.theme;
    }
    private void Start()
    {
        StartVelocity = 7;
        float position = this.gameObject.transform.position.x;
    }

    void Update ()
    {
        StartVelocity =7+0.01f*GroundScript.score;
        transform.Translate(Vector3.down * Time.deltaTime*StartVelocity);
        if (GroundScript.live == false || isfirsttap == true)
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        else if (GroundScript.live == true)
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
	}
    private void FixedUpdate()
    {
        if(isdestroying)
        {
            this.gameObject.transform.localScale /= 1.02f;
        }
    }
    private void OnMouseDown()
    {
        if (Tiletype == TileType.Red)
        {
            Instantiate(Resources.Load("GameOverImage"), GameObject.Find("BackgroundImage").transform);
            GroundScript.live = false;
            Handheld.Vibrate();
            Time.timeScale = 0;
        }
        else if (Tiletype == TileType.Green)
        {
            //Destroy(this.gameObject.GetComponent<BoxCollider>());
            isfirsttap = true;
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            disappear();
            GroundScript.score++;
        }
        else if (Tiletype == TileType.Blue)
        {
            bluefunction();
           // GroundScript.score++;
              //  Tiletype = TileType.Green;

        }
        /*if (SoundToggle.mute == 0)
            AudioSource.PlayClipAtPoint(clip, GameObject.Find("Main Camera").transform.position);*/
    }
    void disappear()
    {
            GameObject parachute = Instantiate(Resources.Load(themenumber+"Parachute"), this.transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            parachute.transform.SetParent(this.gameObject.transform);
            isdestroying = true;
            Destroy(this.gameObject, 0.5f);
    }
    void bluefunction()
    {
        tapCount++;
        GroundScript.score++;
        if(tapCount==1)
        {
            GameObject parachute = Instantiate(Resources.Load(themenumber + "Parachute"), this.transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            parachute.transform.SetParent(this.gameObject.transform);
            parachute.transform.localScale *= 0.66f;
            parachute.transform.position -= new Vector3(0,0.5f,0);
        }
        if(tapCount==2)
        {
            GameObject parachute2 = Instantiate(Resources.Load(themenumber + "Parachute"), this.transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;

            parachute2.transform.SetParent(this.gameObject.transform);
            parachute2.transform.localScale *= 100;
            parachute2.transform.position += new Vector3(0, 5, 0);
            isdestroying = true;
            Destroy(this.gameObject, 0.5f);
        }

        Tiletype = TileType.Green;
    }
}