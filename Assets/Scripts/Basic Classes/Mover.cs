using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class Mover : MonoBehaviour {
	protected Rigidbody rigid;


	//TODO Create a variable which will contain the last mover's velocity modification to revert it.
	protected Vector3 lastVelocityModification;

	// Use this for initialization
	void Awake () {
		rigid = GetComponent<Rigidbody>();	
	}
}
