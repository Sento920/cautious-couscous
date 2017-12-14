using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

	Collider2D collectorArea;
	Rigidbody2D rigidbody2D;
	public float value;

	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		collectorArea = GetComponent<Collider2D>();
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
