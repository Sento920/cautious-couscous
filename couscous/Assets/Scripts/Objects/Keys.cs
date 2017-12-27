using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : Collectible {

	// Use this for initialization
	void Start () {
	value = 0;
	}

void OnTriggerEnter2D(Collider2D other){
		//Destroy ourselves, and re-attach to the Player.
		if(other.gameObject.transform.tag == "player"){
			Collect();
		} else if(other.gameObject.transform.tag == "Door" && ){
			// DOOR!
			OpenLock(other);
		}else{
			//Attach to Monster
		}
	}


	void OpenLock(Object other){
		//get component door controller, check type of door to key (maybe) then unlock the door.
	}

	override public void Collect(){
		GameObject.FindGameObjectWithTag("HUDController").GetComponent<HUDController>().AddKey();
		Destroy(this.gameObject);
	}

}
