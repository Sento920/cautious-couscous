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
			Collect();
		} else {
			// Attach to the Monster
		}
	}
	override public void Collect(){
		GameObject.FindGameObjectWithTag("HUDController").GetComponent<HUDController>().AddGold(value);
		Destroy(this.gameObject);
	}
}