using UnityEngine;
using System.Collections;

public class LaserBolt : Bullet
{

	void OnTriggerEnter (Collider other)
	{
		if (other && other.tag == "Trigger" || other.tag == "Bullet" || other.transform == shooter.transform) {
			return;
		} else if (other && other.tag == "Player" || other.tag == "Enemy" || other.tag == "Neutral") {
			other.GetComponent<DestructibleWithHealth>().TakeDamage(damage);
		}
//		Debug.Log(other.gameObject.name);
		Destruct();
	}
}
