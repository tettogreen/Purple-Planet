using UnityEngine;
using System.Collections;

public class StraightMover : Mover {

	//public float speed;
	public float acceleration;
	public float accelerationTime = 1.2f;

	//Time to allign course if it was changed
	public float turnSpeed;
	public float timeBeforeAlign;
	public bool alignVelocity;

	[Range(-1, 1)]
	public int direcionX;

	[Range(-1, 1)]
	public int direcionY;

	[Range(-1, 1)]
	public int direcionZ;

	//public int fleetModifier;				//Acceleration modifier value during fleet (F = m * a * accelerationModifier)
	public bool useGlobalSpace;

//	private Vector3 velocity;
	private float maxVelocity;
	//private int accelerationModifier;				//Current state of acceleration modifier (F = m * a * accelerationModifier)
	private Vector3 airResistance;
	private float mass;
	private Vector3 thrust;
	private Vector3 resistanceForce;
	private Vector3 accelerationVector;


	// Use this for initialization
	void Start ()
	{
		if (useGlobalSpace) {
			SetAccelerationDirection (Vector3.right, Vector3.up, Vector3.forward);
		} else {
			SetAccelerationDirection (transform.right, transform.up, transform.forward);
		}

		maxVelocity = acceleration * accelerationTime;
		//Rigid initialization...
		if (rigid) {
			mass = rigid.mass;
		}
	}

//	void OnCollisonEnter (Collision collsion)
//	{
//		
//	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		//Moving object if it has no Rigidbody..
		if (!rigid) {
				transform.position += accelerationVector.normalized * maxVelocity * Time.deltaTime;
		} else {
			//Calculation of thrust force
			thrust = mass * accelerationVector;

			if (rigid.velocity.magnitude >= maxVelocity) {
				resistanceForce = -thrust;
			} else {
				float modifier = rigid.velocity.magnitude / maxVelocity;
				resistanceForce = -new Vector3 (Mathf.Pow (thrust.x, modifier), Mathf.Pow (thrust.y, modifier), Mathf.Pow (thrust.z, modifier));
			}
			rigid.AddForce(thrust + resistanceForce);
		}
//		//..Otherwise check if object should allign it's course
//		else if (alignVelocity) {
//
//			if (rigid.velocity != velocity) {
//				StartCoroutine (AlignVelocity ());
//			} else {
//				StopAllCoroutines ();
//			}
//
//		}
	}
//
//	IEnumerator AlignVelocity ()
//	{
//		
//		yield return new WaitForSeconds(timeBeforeAlign);
//		rigid.velocity = Vector3.Lerp(rigid.velocity, velocity, speed * turnSpeed );
//	}

	// Sets velocity according to input axis
	void SetAccelerationDirection (Vector3 xAxis, Vector3 yAxis, Vector3 zAxis)
	{
		//Calculate velocity depending on the directions
		Vector3 accelerationDirection = xAxis.normalized * direcionX + yAxis.normalized * direcionY + zAxis.normalized * direcionZ;
		accelerationVector = acceleration * accelerationDirection.normalized;

		//Add relative objects velocity if it exists
//		if (transform.parent) {
//			velocity += transform.parent.GetC;
//		}

		//Set velocity

//		if (rigid) {
//			velocity += rigid.velocity;
//			rigid.velocity = velocity;
//		}
	}
}
	
