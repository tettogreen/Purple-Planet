using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class Mover : MonoBehaviour {
	protected Rigidbody rigid;

	// Use this for initialization
	void Awake () {
		rigid = GetComponent<Rigidbody>();	
	}
}
