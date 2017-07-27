using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

    void FixedUpdate () {
        this.transform.Translate(Vector2.up * Time.deltaTime * 5);
	}
}
