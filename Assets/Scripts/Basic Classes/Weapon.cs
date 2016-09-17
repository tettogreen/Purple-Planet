using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	//Weight of the gun! Affects shooter's mass.
	public float weight;

	//Shooting charateristics
	public float fireRate;
	public float coolDown;
	public GameObject bulletObject;
	public Transform[] shotSpawns;

	//Audio
	public AudioSource shotSound; 

	protected Spawner spawner;

	void Start ()
	{
		spawner = GetComponent<Spawner>();
		spawner.SpawnPoints = shotSpawns;
		spawner.SpawningSettings (0f, fireRate, coolDown);

	}

		void Update ()
	{

	}
	
	public void StartFire ()
	{
		spawner.StartSpawning();
		if (shotSound && !shotSound.isPlaying) {
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

