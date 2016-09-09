using UnityEngine;
using System.Collections;


//Start fire weapon when player gets into the trigger zone
public class SimpleWeaponAI : MonoBehaviour {

	public Weapon weapon;


	void OnTriggerStay (Collider other)
	{
		//Check if target is in front of the object (shootable)
//		var direction = transform.TransformPoint(transform.up);
//		bool targertLocked = Physics.Raycast (transform.position, direction, viewDistance);
		if ( (other.tag == "Player" || other.tag == "Neutral")) {
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
