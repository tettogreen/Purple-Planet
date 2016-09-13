using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DestructibleWithHealth))]
[RequireComponent(typeof(Rigidbody))]

public class LowHPFleet : MonoBehaviour {

	[Range(0,1)]
	public float lowHPLevel = 0.3f;
	public float fleetSpeedMultiplier;

	private Rigidbody rigid;
	private bool isFleeting = false;
	private float lowHP;
	private Vector3 targetVelocity;


	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
		lowHP = GetComponent<DestructibleWithHealth>().Health * lowHPLevel;
	}

	void FixedUpdate ()
	{
		if (isFleeting) {
			Fleet ();
		}
	}

	public void CheckHealth (int health)
	{
		if (!isFleeting && health <= lowHP) {
			targetVelocity = rigid.velocity * fleetSpeedMultiplier;
			isFleeting = true;
		}
	}


	void Fleet ()
	{	
		if (rigid.velocity.magnitude < targetVelocity.magnitude) {
			rigid.AddForce (transform.forward * 10, ForceMode.Acceleration);
		}
	}
}