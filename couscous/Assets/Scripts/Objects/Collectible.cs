using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

	Collider2D collectorArea;
	Rigidbody2D rigidbody2D;

	GameController gameController;
	 public float value;


	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		collectorArea = GetComponent<Collider2D>();
	}

	void OnTriggerEnter2D(Collider2D other){
		//Destroy ourselves, and re-attach to the Player.
		if(other.gameObject.transform.tag == "player"){
			Debug.Log("Player touch");
			FindObjectOfType<HUDController>().AddGold(value);
			Destroy(this.gameObject);
		} else {
			// Attach to the Monster
		}
	}

	public float getValue(){
		return value;
	} 

	void DisableCollider(){
		this.collectorArea.enabled = false;
	}

	void EnableCollider(){
		this.collectorArea.enabled = true;
	}

}
