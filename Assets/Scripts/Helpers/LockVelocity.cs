using UnityEngine;
using System.Collections;

public class LockVelocity : MonoBehaviour {

//	public bool x, y, z;
//
//	private Vector3  lockedVelocity;
//	private Rigidbody rigid;
//
//	// Use this for initialization
//	void Start () {
//		rigid = GetComponent<Rigidbody>();
//	}
//	
//	// Update is called once per frame
//	void FixedUpdate ()
//	{
//		lockedVelocity = rigid.velocity;
//		if (x) {
//			lockedVelocity.x = 0;
//		}
//		if (y) {
//			lockedVelocity.y = 0;
//		}
//		if (z) {
//			lockedVelocity.z = 0;
//		}
//
//		float multiplier = rigid.velocity.magnitude / lockedVelocity.magnitude;
//		Vector3 vect = lockedVelocity * multiplier;
//		rigid.velocity = lockedVelocity * multiplier;
//	}
}
