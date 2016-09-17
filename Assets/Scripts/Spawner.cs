using UnityEngine;
using System.Collections;

public class Spawner : ObjectPool {

	public bool automaticStart = false;
	//Time before the first spawn
	public float startWait {get; set;}
	//Time between each spawn
	public float spawnWait;
	//Time between waves
	public float waveWait;
	public float waveTime;

	private float nextSpawn;
	private bool isSpawning = false;
	private bool noWaves;
	private float waveEnd;



	[SerializeField]
	protected Transform[] spawnPoints;
	public Transform[] SpawnPoints {	
		get { return spawnPoints; }
		set	{ spawnPoints = value; } 
	}


	protected override void Awake() {
		base.Awake();

		if (waveTime == 0 || waveWait == 0) {
			noWaves = true;
		}
	}

	void Start ()
	{
		if (automaticStart) {
			StartCoroutine (SpawnWaves ());
		}

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

					spawnie.transform.position = spawnPoint.transform.position;
					spawnie.transform.rotation = spawnPoint.transform.rotation;

//					//Add relative velocity
//					if (spawnieRigid && spawnerRigid.velocity.magnitude != 0f ) {
//						Debug.Log(spawnieRigid.velocity);
//					}

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

	/// <summary>
	/// Set time before the first wave, between spawns and between the waves
	/// </summary>
	public void SpawningSettings (  float beforeFirstWave, float betweenSpawn, float betweenWaves ) 
	{
//		pooledObject = spawnieObject;
		startWait = beforeFirstWave;
		spawnWait = betweenSpawn;
		waveWait = betweenWaves;
	}
}
