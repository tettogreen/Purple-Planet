using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	protected Rigidbody rigid;

	// Use this for initialization
	void Awake () {
		rigid = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
