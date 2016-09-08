using UnityEngine;
using System.Collections;

public class LowHPFleet : MonoBehaviour {

	private Rigidbody rigid;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
	}

	public void Fleet (float speed)
	{
		if (rigid) {
			rigid.velocity *= speed;
		}
	}
}
