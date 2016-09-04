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
	public float waveWait;

	private bool isSpawning = false;

	void Start ()
	{
		if (automaticStart) {
			StartCoroutine (SpawnWaves ());
		}
	}

	//Couritne!
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (gameObject != null) {
			foreach (Transform spawnPoint in SpawnPoints) {
				GameObject spawnie = PoolObject ();
				//spawnie.transform.position = spawnValues;
				spawnie.transform.position = spawnPoint.transform.position;
				spawnie.transform.rotation = spawnPoint.transform.rotation;
				spawnie.SetActive (true);
			}
			yield return new WaitForSeconds (spawnWait);
		}
		yield return new WaitForSeconds (waveWait);
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
		if (isSpawning == false) {
			StartCoroutine (SpawnWaves());
		} 
	}

	public void StopSpawning ()
	{
		StopAllCoroutines();
	}
}
