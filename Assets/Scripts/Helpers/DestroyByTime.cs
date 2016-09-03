using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {

	public bool activated;
	public float time;
	// Use this for initialization
	void Start ()
	{
		if (activated) {
			Activate();
		}
	}

	void Activate ()
	{
		if (GetComponent<Destructible>() != null) {
			StartCoroutine (GetComponent<Destructible> ().Destruct (time));
		} else {
			Destroy (gameObject, time);
		}
	}

}
