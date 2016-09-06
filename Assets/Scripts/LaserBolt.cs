using UnityEngine;
using System.Collections;

public class LaserBolt : Bullet
{

	void OnTriggerEnter (Collider other)
	{
		FindShooter(transform.parent);

		if (other.tag == "Boundary" || other.tag == "Bullet" || other.transform == shooter.transform) {
			return;
		} else if (other.tag == "Player" || other.tag == "Enemy") {
			other.GetComponent<DestructibleWithHealth>().TakeDamage(damage);
		}
		//Debug.Log(other.gameObject.name);
		Destruct();
	}
}
