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
	public bool useGlobalSpace;

	private Rigidbody rigid;
	private Vector3 direction;

	// Use this for initialization
	void Start ()
	{
		rigid = GetComponent<Rigidbody> ();
		if (useGlobalSpace) {
			SetDirection (Vector3.right, Vector3.up, Vector3.forward);
		} else {
			SetDirection (transform.right, transform.up, transform.forward);
		}
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

	// Sets direction according to input axis
	void SetDirection (Vector3 xAxis, Vector3 yAxis, Vector3 zAxis)
	{
		direction = xAxis * direcionX + yAxis * direcionY + zAxis * direcionZ;
		rigid.velocity = direction * speed;
	}
}
	
