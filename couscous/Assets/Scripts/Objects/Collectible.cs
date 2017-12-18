using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour {

	public Collider2D collectorArea;
	public Rigidbody2D rigidbody2D;
	public float value;

	

	public float getValue(){
		return value;
	} 

	void DisableCollider(){
		this.collectorArea.enabled = false;
	}

	void EnableCollider(){
		this.collectorArea.enabled = true;
	}

	void collect(){
		
	}

}
