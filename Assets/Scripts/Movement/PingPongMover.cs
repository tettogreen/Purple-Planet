﻿using UnityEngine;
using System.Collections;

public class PingPongMover : Mover{

//	[Range(0, 20)]
//	public float x;

	[Range(0,5)]
	public float time;

	[Range(-1, 1)]
	public int initialDirection;
	public float speed;

	private float nextChangeTime;
	private Vector3 targetVelocity;

//	private Vector3 minimalX, maximumX;
	
	// Use this for initialization
	void Start () {
//		initialPosition = transform.position;
		velocityModification = new Vector3 (initialDirection * speed , 0f, 0f);
		rigid.velocity += velocityModification;
		targetVelocity = rigid.velocity;
		nextChangeTime = Time.time + time / 2;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
//		if (transform.position.x > initialPosition.x + x || transform.position.x > initialPosition.x - x) {
//			rigid.velocity = new Vector3 (-rigid.velocity.x, rigid.velocity.y, rigid.velocity.z);
//		}

		if (Time.time > nextChangeTime) {

			//Legacy version (no revert option)
//			velocityModification = new Vector3 (-rigid.velocity.x, rigid.velocity.y, rigid.velocity.z);
//			rigid.velocity = Vector3.Lerp (rigid.velocity, velocityModification, speed)

			velocityModification = new Vector3 (-2 * rigid.velocity.x, 0f, 0f);
			targetVelocity = rigid.velocity + velocityModification;
			nextChangeTime = Time.time + time;
		}

		if (rigid.velocity != targetVelocity) {
			rigid.velocity = Vector3.Lerp (rigid.velocity, targetVelocity, 0.05f * speed);
		}
	}
}
