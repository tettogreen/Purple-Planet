using UnityEngine;
using System.Collections;

public class WakeTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		Debug.Log (other.name);
		var sds = other.GetComponent<Mover>();
		if (sds!= null && sds.enabled == false) {
			Debug.Log (sds.GetType().ToString());
			sds.enabled = true;
		}
	}
}
