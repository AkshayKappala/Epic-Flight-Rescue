using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorkMovement : MonoBehaviour {
    public int MovementSpeed;
    private void Start()
    {
        Destroy(this.gameObject, 10);
    }
    void Update ()
    {
        transform.Translate(Vector2.left * Time.deltaTime * MovementSpeed);
    }
    private void OnMouseDown()
    {
        Destroy(this.gameObject);
    }
}
