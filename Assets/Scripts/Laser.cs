using UnityEngine;
using System.Collections;

public class Laser : Weapon
{
	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.up * speed;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Bullet" || other.gameObject == shooter) {
			return;
		}
		if (other.tag == "Player" || other.tag == "Enemy") {
			other.GetComponent<Destructible>().TakeDamage(damage);
		}
		Debug.Log(other.gameObject.name);
		Destroy(gameObject);
	}
}
