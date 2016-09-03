using UnityEngine;
using System.Collections;

public class StraightMover : Mover {

	public float speed;

	[Range(-1, 1)]
	public int direcionX;

	[Range(-1, 1)]
	public int direcionY;

	[Range(-1, 1)]
	public int direcionZ;


	// Use this for initialization
	void Start () {
		Vector3 direction = new Vector3 (direcionX, direcionY, direcionZ);
		GetComponent<Rigidbody>().velocity = direction * speed;
	}

//	void OnCollisonEnter (Collision collsion)
//	{
//		
//	}

	// Update is called once per frame
	void Update () {
	}
}
