using UnityEngine;
using System.Collections;

public class Weapon : Spawner {


	public GameObject shot;
	public Transform[] shotSpawns;
	public float fireRate;

	//Audio
	public AudioSource shotSound;

	private float nextFire;

		void Update ()
	{
		//Shooting
		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
			Debug.Log("Started shooting");
			nextFire = Time.time + fireRate;
			StartFire ();
			if (shotSound) {
				shotSound.loop = true;
				shotSound.Play ();
			}
		}
		if (Input.GetButtonUp ("Fire1")) {
			Debug.Log("Ended shooting");
			StopFire ();
			shotSound.loop = false;
		}
	}
	
	public void StartFire ()
	{
		StartSpawning();
	}

	public void StopFire ()
	{
		StopSpawning();
	}
}

