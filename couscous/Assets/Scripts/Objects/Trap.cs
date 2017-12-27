using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour {

	public bool Active;
	public bool InstaKill;
	public float damage;
	public abstract void Damage(GameObject other);
}
