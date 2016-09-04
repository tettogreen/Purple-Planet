using UnityEngine;
using System.Collections;
using System.Linq;

[System.Serializable]
public class Boundery {
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Boundery boundery;
	public float tilt;
	public Done_Boundary boundary;
	private Rigidbody rigid;

	public GameObject[] weapons;
	public GameObject shot;
	public Transform[] shotSpawns;
	public float fireRate;

	//Audio
	private DestructibleSoundController soundPlayer;

	private float nextFire;

	void Awake() {
		rigid = GetComponent<Rigidbody>();
		soundPlayer = GetComponentInChildren<DestructibleSoundController>();


	}

	void FixedUpdate ()
	{
		//Shooting
		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			StartFire();
			soundPlayer.PlayShot ();
		}
		if (Input.GetButtonUp ("Fire1") && Time.time > nextFire) {
			StopFire();
		}
//		if

		//Movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		//movement = transform.position + movement;
//            var mousePosition = Input.mousePosition;
//            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
//		transform.position = Vector2.Lerp (transform.position, movement, speed);
		rigid.velocity = movement * speed;
		rigid.position = new Vector3 (
			Mathf.Clamp (rigid.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rigid.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);

		//Tilt
		rigid.rotation = Quaternion.Euler (movement.y * tilt * 0.5f, -movement.x * tilt, 0.0f);
	}

	private void StartFire ()
	{
		weapons[0].GetComponent<Spawner>().StartSpawning();
	}

	private void StopFire ()
	{
		weapons[0].GetComponent<Spawner>().StopSpawning();
	}

 	public void Destruct ()
	{
		//TODO Add GameOver() action
	}

//	IEnumerator Shoot ()
//	{
//		
//		nextFire = Time.time + fireRate;
//		foreach (var shotSpawn in shotSpawns) {
//		//locking x rotation and then instantiating a shot
//		Vector3 rotation = new Vector3 (0.0f, shotSpawn.rotation.y, shotSpawn.rotation.z);
//		Instantiate (shot, shotSpawn.position, Quaternion.Euler(rotation), transform);
//		}
//		soundPlayer.PlayShot();
//	}
}
