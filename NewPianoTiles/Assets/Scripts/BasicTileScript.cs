using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


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
        StartVelocity =startvelocityref+0.01f* UIManager.Instance.score;
        transform.Translate(Vector3.down * Time.deltaTime*StartVelocity);
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
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Tiletype == TileType.Red)
            {
                Instantiate(Resources.Load("PoofBlack"), this.transform.position, Quaternion.identity);
                UIManager.Instance.ShowGameOverMenu();
            }
            else if (Tiletype == TileType.Green)
            {
                greenfunction();
            }
            else if (Tiletype == TileType.Blue)
            {
                bluefunction2();
            }
            /*if (SoundToggle.mute == 0)
                AudioSource.PlayClipAtPoint(clip, GameObject.Find("Main Camera").transform.position);*/
        }
    }


    void greenfunction()
    {
        isfirsttap = true;
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        GameObject parachute = Instantiate(Resources.Load(themenumber + "Parachute"), this.transform.position + new Vector3(0, 1 , 0), Quaternion.identity) as GameObject;
        parachute.transform.SetParent(this.gameObject.transform);
        isdestroying = true;
        Destroy(this.gameObject, 0.5f);
        UIManager.Instance.score++;
    }
   
    void bluefunction2()
    {
        UIManager.Instance.score++;
        if (isFirstBlueChute == true)
        {
            blueParachute1 = Instantiate(Resources.Load(themenumber + "BlueParachute1"), this.transform.position, Quaternion.identity) as GameObject;
            blueParachute1.transform.SetParent(this.gameObject.transform);
            blueParachute1.transform.position += new Vector3(0, 1.75f, 0);
            isFirstBlueChute = false;
        }
        else if(isFirstBlueChute == false)
        {
            isfirsttap = true;
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            Destroy(blueParachute1);
            GameObject parachute = Instantiate(Resources.Load(themenumber + "BlueParachute2"), this.transform.position, Quaternion.identity) as GameObject;
            parachute.transform.SetParent(this.gameObject.transform);
            parachute.transform.position += new Vector3(0, 1.75f, 0);
            isdestroying = true;
           // Time.timeScale = 0;
            Destroy(this.gameObject, 0.5f);
        }
        
    }
}