using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {

	public bool activateManually;
	public float time;
	// Use this for initialization
	void Start ()
	{
		if (!activateManually) {
			Activate();
		}
	}

	void Activate ()
	{
		if (GetComponent<Destructible>() != null) {
			GetComponent<Destructible> ().Destruct (time);
		} else {
			Destroy (gameObject, time);
		}
	}

}
