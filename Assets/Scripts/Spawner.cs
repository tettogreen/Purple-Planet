using UnityEngine;
using System.Collections;

public class Spawner : ObjectPool {

	public Transform[] SpawnPoints;
	public bool automaticStart;
	//Time before the first spawn
	public float startWait;
	//Time between each spawn
	public float spawnWait;
	//Time between waves
	public float waveTime;
	public float waveWait;

	private float nextSpawn = 0;
	private bool isSpawning = false;
	private bool noWaves = false;
	private float waveEnd;

	void Start ()
	{
		if (automaticStart) {
			StartCoroutine (SpawnWaves ());
		}

		noWaves = true;
	}

	//Couritne!
	IEnumerator SpawnWaves ()
	{
		if (startWait != 0f) {
			yield return new WaitForSeconds (startWait);
		}

		while ((gameObject != null)) {


			if (!noWaves) {
				waveEnd = Time.time + waveTime;
			}
			
			while (noWaves || Time.time < waveEnd) {
				//to prevent double spawning when SpawnWaves is called twice in a short time
				if (Time.time < nextSpawn) {
					yield return new WaitForSeconds (nextSpawn - Time.time);
				}
//
				foreach (Transform spawnPoint in SpawnPoints) {
					GameObject spawnie = PoolObject ();
					//spawnie.transform.position = spawnValues;
					spawnie.transform.position = spawnPoint.transform.position;
					spawnie.transform.rotation = spawnPoint.transform.rotation;
					spawnie.SetActive (true);
					nextSpawn = Time.time + spawnWait;
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void StartSpawning (float startDelay, float spawnInterval, float waveInterval)
	{
		startDelay = startWait;
		spawnWait = spawnInterval;
		waveWait = waveInterval;
		StartSpawning();
	}

	public void StartSpawning ()
	{
		if (!isSpawning) {
			StartCoroutine (SpawnWaves());
			isSpawning = true;
		} 
	}

	public void StopSpawning ()
	{
		if (isSpawning) {
			StopAllCoroutines ();
			isSpawning = false;
		}
	}
}
