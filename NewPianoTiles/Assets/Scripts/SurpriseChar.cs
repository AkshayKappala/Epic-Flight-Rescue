using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseChar : MonoBehaviour
{
    public static float StartVelocity;
    [HideInInspector]
    public float selector;
    public GameObject GeneratedChar;
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
    }

    private void OnMouseDown()
    {
        if(selector<3)
        {
            Instantiate(Resources.Load(themenumber + "RescueCharRed"), this.transform.position, Quaternion.identity);
           
        }
        else
        {
            GeneratedChar = Instantiate(Resources.Load(themenumber + "RescueCharGreen"), this.transform.position, Quaternion.identity) as GameObject;
            GeneratedChar.layer = 13;
        }
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        Instantiate(Resources.Load("PoofWhite"), this.transform.position, Quaternion.identity);
    }
}
