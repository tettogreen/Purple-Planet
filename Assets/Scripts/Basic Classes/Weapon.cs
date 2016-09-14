using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Spawner))]

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

