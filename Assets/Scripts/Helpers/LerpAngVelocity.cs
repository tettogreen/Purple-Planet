using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class LerpAngVelocity : MonoBehaviour {

	Rigidbody rigid;

	void Start ()
	{
		rigid = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		if (rigid.angularVelocity != Vector3.zero) {
			rigid.angularVelocity = Vector3.Lerp(rigid.angularVelocity, new Vector3(0f, 0f, 0f), 1f);
		}
	}
}
