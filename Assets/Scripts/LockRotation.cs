using UnityEngine;
using System.Collections;

public class LockRotation : MonoBehaviour {

	public bool x;
	public bool y;
	public bool z;

	// Update is called once per frame
	void Update ()
	{
		Vector3 rotation = transform.rotation.eulerAngles;
		if (x) {
			rotation.x = 0.0f;
		}
		if (y) {
			rotation.y = 0.0f;
		}
		if (z) {
			rotation.z = 0.0f;
		}
		transform.rotation = Quaternion.Euler (rotation);
	}
}
