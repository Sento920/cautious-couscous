using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : Trap {
	float timer;
	public float timeLimit;
	public float volumeX;
	public float volumeY;
	public float knockback;
	public bool offset;

	// Use this for initialization
	void Start () {
		if(InstaKill){
			damage = 1000f;
		}
		if(offset){
			timer += timeLimit;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Active){
			timer -= Time.deltaTime;
			if(timer < 0){
				Switch();			
			}
		}else{
			//gameObject.SetActive(false);
		}
	}

	void Switch(){
		Active = !Active;
		timer = timeLimit;
	}

	void OnCollisionEnter2D(Collider2D other){
		Damage(other.gameObject);
		other.GetComponent<Rigidbody2D>().AddForce(-gameObject.transform.InverseTransformVector(other.transform.position) * knockback);
	}

	override public void Damage(GameObject other){
		Debug.Log("Damaged Something: " + other.gameObject.name);
	}
}
