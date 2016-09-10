using UnityEngine;
using System.Collections;

public class StraightMover : Mover {

	public float speed;

	//Time to allign course if it was changed
	public float turnSpeed;
	public float timeBeforeAlign;

	//Start velocity will be relative to this object, 
	//	e.g. when ship is flying and shooting start vel of bullets should be equal to ships velocity + it's own velocity
	//public Rigidbody relativeObject;

	[Range(-1, 1)]
	public int direcionX;

	[Range(-1, 1)]
	public int direcionY;

	[Range(-1, 1)]
	public int direcionZ;
	public bool useGlobalSpace;

	private Rigidbody rigid;
	private Vector3 velocity;
	// Use this for initialization
	void Start ()
	{
		rigid = GetComponent<Rigidbody> ();
		if (useGlobalSpace) {
			SetVelocity (Vector3.right, Vector3.up, Vector3.forward);
		} else {
			SetVelocity (transform.right, transform.up, transform.forward);
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
			transform.position += velocity * Time.deltaTime;
		}
		//..Otherwise check if object should allign it's course
		else if (rigid.velocity != velocity) {
			StartCoroutine (AlignVelocity ());
		} else {
			StopAllCoroutines();
		}
	}

	IEnumerator AlignVelocity ()
	{
		yield return new WaitForSeconds(timeBeforeAlign);
		rigid.velocity = Vector3.Lerp(rigid.velocity, velocity, speed * turnSpeed );
	}

	// Sets velocity according to input axis
	void SetVelocity (Vector3 xAxis, Vector3 yAxis, Vector3 zAxis)
	{
		//Calculate velocity depending on the directions
		velocity = xAxis * direcionX + yAxis * direcionY + zAxis * direcionZ;
		velocity *= speed;

		//Add relative objects velocity if it exists
//		if (transform.parent) {
//			velocity += transform.parent.GetC;
//		}

		//Set velocity
		if (rigid) {
			velocity += rigid.velocity;
			rigid.velocity = velocity;
		}
	}
}
	
