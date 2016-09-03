using UnityEngine;
using System.Collections;

public class Spawner : ObjectPool {

	public Transform[] SpawnPoints;
//	public Vector3 spawnValues;
//	public int spawniesCount;
	//Time between each spawn
	public float spawnWait;
	//Time before the first spawn
	public float startWait;
	//Time between waves
	public float waveWait;

	void Start ()
	{
		StartCoroutine (SpawnWaves());
	}

	//Couritne!
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (gameObject != null) {
			foreach (Transform spawnPoint in SpawnPoints) {
				Quaternion spawnRotation = Quaternion.identity;
				GameObject spawnie = PoolObject ();
				//spawnie.transform.position = spawnValues;
				spawnie.transform.position = spawnPoint.transform.position;
				spawnie.SetActive (true);
			}
			yield return new WaitForSeconds (spawnWait);
		}
		yield return new WaitForSeconds (waveWait);
	}
}
