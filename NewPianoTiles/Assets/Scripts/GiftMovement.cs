using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftMovement : MonoBehaviour {
	void Update ()
    {
        transform.Translate(Vector2.down * Time.deltaTime * BasicTileScript.StartVelocity);
	}
    private void OnMouseDown()
    {
        Economy.coins += 50;
        PlayerPrefs.SetInt("Coins", Economy.coins);
        Destroy(this.gameObject);
        //write coin increment code here
    }
}
