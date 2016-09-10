using UnityEngine;
using System.Collections;

public class PingPongMover : Mover{

	[Range(-20, 20)]
	public float x, y, z;
	public float speed;

	private Vector3 initialPosition;
	
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		rigid.velocity += 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
