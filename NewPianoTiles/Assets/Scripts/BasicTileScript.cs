using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicTileScript : MonoBehaviour
{
    public static float StartVelocity;
    public float startvelocityref;
    public bool isdestroying = false;
    [HideInInspector]
    public bool isfirsttap=false;
    public TileType Tiletype;
    private AudioClip clip;
    public int themenumber;
    [HideInInspector]
    public float extraYblue=0;
    public bool isFirstBlueChute = true;
    public GameObject blueParachute1;
    private void Awake()
    {
        themenumber = GameController.theme;
    }
    private void Start()
    {
        StartVelocity = 7;
        startvelocityref = StartVelocity;
        float position = this.gameObject.transform.position.x;
    }

    void Update ()
    {
        StartVelocity =startvelocityref+0.01f*GroundScript.score;
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
            isfirsttap = true;
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            disappear();
            GroundScript.score++;
        }
        else if (Tiletype == TileType.Blue)
        {
            bluefunction2();

        }
        /*if (SoundToggle.mute == 0)
            AudioSource.PlayClipAtPoint(clip, GameObject.Find("Main Camera").transform.position);*/
    }
    void disappear()
    {
            GameObject parachute = Instantiate(Resources.Load(themenumber+"Parachute"), this.transform.position + new Vector3(0, 1+extraYblue, 0), Quaternion.identity) as GameObject;
        extraYblue = 0;
            parachute.transform.SetParent(this.gameObject.transform);
            isdestroying = true;
            Destroy(this.gameObject, 0.5f);
    }
   
    void bluefunction()
    {
        GroundScript.score++;

            GameObject parachute = Instantiate(Resources.Load("2Parachute2"), this.transform.position, Quaternion.identity) as GameObject;
            parachute.transform.SetParent(this.gameObject.transform);
            parachute.transform.position += new Vector3(0, 1, 0);
        extraYblue = 0.75f;
        startvelocityref = 5;
        Tiletype = TileType.Green;
    }
    void bluefunction2()
    {
        GroundScript.score++;
        if (isFirstBlueChute == true)
        {
            blueParachute1 = Instantiate(Resources.Load(themenumber + "BlueParachute1"), this.transform.position, Quaternion.identity) as GameObject;
            blueParachute1.transform.SetParent(this.gameObject.transform);
            blueParachute1.transform.position += new Vector3(0, 1.75f, 0);
            isFirstBlueChute = false;
        }
        else if(isfirsttap==false)
        {
            Destroy(blueParachute1);
            GameObject parachute = Instantiate(Resources.Load(themenumber + "BlueParachute2"), this.transform.position, Quaternion.identity) as GameObject;
            parachute.transform.SetParent(this.gameObject.transform);
            parachute.transform.position += new Vector3(0, 1.75f, 0);
            isdestroying = true;
            Destroy(this.gameObject, 0.5f);
        }
        
    }
}