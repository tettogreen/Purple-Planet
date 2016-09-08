using UnityEngine;
using System.Collections;

public class SimpleWeaponAI : MonoBehaviour {

	private Weapon weapon;

	void Awake ()
	{
		weapon = GetComponentInChildren<Weapon>();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			weapon.StartFire();
		}
	}

}
