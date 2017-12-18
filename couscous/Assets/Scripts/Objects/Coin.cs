using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectible {
	
void Start(){
	collectorArea = GetComponent<BoxCollider2D>();
}

void OnTriggerEnter2D(Collider2D other){
		//Destroy ourselves, and re-attach to the Player.
		if(other.gameObject.transform.tag == "Player"){
			Debug.Log("Player touch");
			GameObject.FindGameObjectWithTag("HUDController").GetComponent<HUDController>().AddGold(value);
			Destroy(this.gameObject);
		} else {
			// Attach to the Monster
		}
	}
}
