using UnityEngine;
using System.Collections;

public class Done_RandomRotator : MonoBehaviour 
{
	public float tumble;

	Rigidbody rigid;
	
	void Start ()
	{
		rigid = GetComponent<Rigidbody>();
		rigid.angularVelocity = Random.insideUnitSphere * tumble;
	}
}