using UnityEngine;
using System.Collections;

public class CitizenShipAI : DestructibleWithHealth {

	public int lowHP;
	public float fleetSpeedMultiplier;

	private Rigidbody rigid;
	
	public override int Health {
		get {
			return health;
		}
		set {
			if (value < lowHP) {
				Fleet ();
			}
			health = value;
		}
	}
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
	}

	public void Fleet ()
	{
		if (rigid) {
			rigid.velocity *= Mathf.Lerp(0f, fleetSpeedMultiplier, 1);
		}
	}
}
