using UnityEngine;
using System.Collections;

public class LerpAngVelocity : MonoBehaviour {


	void FixedUpdate () {
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		if (rigidbody.angularVelocity != Vector3.zero) {
			rigidbody.angularVelocity = Vector3.Lerp(rigidbody.angularVelocity, new Vector3(0f, 0f, 0f), 1);
		}
	}
}
