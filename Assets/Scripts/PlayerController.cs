using UnityEngine;
using System.Collections;
using System.Linq;

[System.Serializable]
public class Boundary {
	public Vector2 Min, Max;

}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Boundary boundary;
	public float tilt;
	public Weapon[] weapons;

	private float nextFire, fireRate;


	private Rigidbody rigid;
	private int currentWeapon = 0;

	void Awake ()
	{
		rigid = GetComponent<Rigidbody> ();
		weapons = GetComponentsInChildren<Weapon>();

	}


	void FixedUpdate ()
	{


		//Movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		//movement = transform.position + movement;
//            var mousePosition = Input.mousePosition;
//            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
//		transform.position = Vector2.Lerp (transform.position, movement, speed);
		rigid.velocity = movement * speed;

		Vector2 min = transform.parent.TransformPoint(boundary.Min);
		Vector2 max = transform.parent.TransformPoint(boundary.Max);
		rigid.position = new Vector3 (
			Mathf.Clamp (rigid.position.x, min.x, max.x),
			Mathf.Clamp (rigid.position.y, min.y, max.y),
			0.0f
		);

		//Tilt
		rigid.rotation = Quaternion.Euler (movement.y * tilt * 0.5f, -movement.x * tilt, 0.0f);
	}

	void Update ()
	{
		//Shooting
		if (Input.GetButtonUp ("Fire1")) {
			Debug.Log("Ended shooting");
			weapons[currentWeapon].StopFire ();
		}
		if (Input.GetButton ("Fire1") ) {
			Debug.Log("Started shooting");
			nextFire = Time.time + fireRate;
			weapons[currentWeapon].StartFire ();
		}
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
