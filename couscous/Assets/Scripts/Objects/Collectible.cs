using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

	Collider2D collectorArea;
	Rigidbody2D rigidbody2D;


	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		collectorArea = GetComponent<Collider2D>();
	}

	void OnTriggerEnter2D(Collider other){
		//Destroy ourselves, and re-attach to the Player.
		if(other.gameObject.transform.tag == "player"){
			Debug.Log("Player touch");
		} else {
			Debug.Log("Non-Player Touch");
		}
	}

}
