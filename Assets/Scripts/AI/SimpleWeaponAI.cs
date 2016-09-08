using UnityEngine;
using System.Collections;


//Start fire weapon when player gets into the trigger zone
public class SimpleWeaponAI : MonoBehaviour {

	public Weapon weapon;


	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player" || other.tag == "Neutral") {
			weapon.StartFire();
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player" || other.tag == "Neutral") {
			weapon.StopFire();
		}
	}
}
