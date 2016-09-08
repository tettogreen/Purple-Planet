using UnityEngine;
using System.Collections;

public class WakeTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
//		Debug.Log (other.name);
		if (other.tag == "Enemy" || other.tag == "Neutral" ) {
			MonoBehaviour[] scripts = other.GetComponents<MonoBehaviour> ();
			foreach (MonoBehaviour script in scripts) {
			EnableComponent (script);
			}
		}
	}

	void EnableComponent (MonoBehaviour script)
	{
		if (script && !script.enabled) {
//			Debug.Log (mover.GetType ().ToString ());
			script.enabled = true;
		}
	}
}
