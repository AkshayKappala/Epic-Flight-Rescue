using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        StartVelocity = 10;
        selector = Random.Range(1, 5);
    }
    void Update()
    {
        StartVelocity = 10 + 0.01f * UIManager.Instance.score;
        transform.Translate(Vector3.down * Time.deltaTime * StartVelocity);
    }

    private void OnMouseDown()
    {
        if (!IsPointerOverUIObject())
        {
            if (selector < 3)
            {
                Instantiate(Resources.Load(themenumber + "RescueCharRed"), this.transform.position, Quaternion.identity);

            }
            else
            {
                GeneratedChar = Instantiate(Resources.Load(themenumber + "RescueCharGreen"), this.transform.position, Quaternion.identity) as GameObject;
                GeneratedChar.layer = 13;
            }
            Destroy(this.gameObject);
            Instantiate(Resources.Load("PoofWhite"), this.transform.position, Quaternion.identity);
        }
    }

    //below method is written in substitution to EventSystem.current.IsPointerOverGameObject()
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
