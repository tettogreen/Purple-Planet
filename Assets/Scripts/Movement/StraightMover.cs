using UnityEngine;
using System.Collections;

public class StraightMover : Mover {

	public float speed;
	//Time to allign course if it was changed
	public float turnSpeed;
	public float timeBeforeAlign;

	[Range(-1, 1)]
	public int direcionX;

	[Range(-1, 1)]
	public int direcionY;

	[Range(-1, 1)]
	public int direcionZ;

	private Rigidbody rigid;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
		direction = new Vector3 (direcionX, direcionY, direcionZ);
		rigid.velocity = direction * speed;
	}

//	void OnCollisonEnter (Collision collsion)
//	{
//		
//	}

	// Update is called once per frame
	void Update ()
	{
		if (rigid.velocity != direction * speed) {
			StartCoroutine (AlignVelocity());
		}
	}

	IEnumerator AlignVelocity ()
	{
		yield return new WaitForSeconds(timeBeforeAlign);
		rigid.velocity = Vector3.Lerp(rigid.velocity, direction * speed, speed * turnSpeed );
	}

//	void Align ()
//	{
//		rigid.velocity = Vector3.Lerp(rigid.velocity, direction * speed,  turnSpeed );
//	}

//	void OnCollisionExit (Collision collision)
//	{
//		if (rigid.velocity != direction * speed) {
//			Align();
//		}
//	}
}
