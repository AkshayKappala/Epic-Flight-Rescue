using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicTileScript : MonoBehaviour
{
    public static float StartVelocity;
    [HideInInspector]
    public GameObject greener;
    public bool isdestroying = false;
    [HideInInspector]
    public bool isfirsttap=false;
    public TileType Tiletype;
    private AudioClip clip;
    private void Start()
    {
        StartVelocity = 7;
        float position = this.gameObject.transform.position.x;
      /*  if (Tiletype==TileType.Red)
        {
            clip = (AudioClip)Resources.Load("error");
        }
        else if (position == -4.07f)
            clip = (AudioClip)Resources.Load("Sound1");
        else if (position == -1.36f)
            clip = (AudioClip)Resources.Load("Sound2");
        else if (position == 1.36f)
            clip = (AudioClip)Resources.Load("Sound3");
        else if (position == 4.06f)
            clip = (AudioClip)Resources.Load("Sound4");*/
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
            GroundScript.score++;
            Tiletype = TileType.Green;
        }
        /*if (SoundToggle.mute == 0)
            AudioSource.PlayClipAtPoint(clip, GameObject.Find("Main Camera").transform.position);*/
    }
    void disappear()
    {
            GameObject parachute = Instantiate(Resources.Load("Parachute"), this.transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            parachute.transform.SetParent(this.gameObject.transform);
            isdestroying = true;
            Destroy(this.gameObject, 0.5f);
    }
}