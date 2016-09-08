using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {


	public GameObject shot;
	public Transform[] shotSpawns;

	//Audio
	public AudioSource shotSound;

	private Spawner spawner;

	void Start ()
	{
		spawner = GetComponent<Spawner>();
	}

		void Update ()
	{
//		//Shooting
//		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
//			Debug.Log("Started shooting");
//			nextFire = Time.time + fireRate;
//			StartFire ();
//		}
//		if (Input.GetButtonUp ("Fire1")) {
//			Debug.Log("Ended shooting");
//			StopFire ();
//		}
	}
	
	public void StartFire ()
	{
		spawner.StartSpawning();
		if (shotSound) {
			shotSound.loop = true;
			shotSound.Play ();
		}
	}

	public void StopFire ()
	{
		spawner.StopSpawning();
		shotSound.loop = false;
	}
}

