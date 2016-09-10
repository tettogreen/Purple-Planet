using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit (Collider other)
	{
		Destructible destructible = other.GetComponent<Destructible> ();
		if (destructible != null) {
			other.GetComponent<Destructible> ().Destruct ();
		} else {
			Destroy(other.gameObject);
		}
//        Debug.Log (other);
    }
}
