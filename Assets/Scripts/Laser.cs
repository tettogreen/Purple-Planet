using UnityEngine;
using System.Collections;

public class Laser : Weapon
{

	void OnTriggerEnter (Collider other)
	{
		FindOwner(transform.parent);

		if (other.tag == "Boundary" || other.tag == "Bullet" || other.transform == owner.transform) {
			return;
		} else if (other.tag == "Player" || other.tag == "Enemy") {
			other.GetComponent<DestructibleWithHealth>().TakeDamage(damage);
		}
		//Debug.Log(other.gameObject.name);
		Destruct();
	}
}
