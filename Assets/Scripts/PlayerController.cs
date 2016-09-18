using UnityEngine;
using System.Collections;
using System.Linq;

[System.Serializable]
public class Boundary {
	public Vector3 Min, Max;

}

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour 
{
	public float maxVelocity;
	public float enginePower;
	public Boundary boundary;
	public float tilt;

	private Weapon[] weapons;
//	private float nextFire, fireRate;



	private Rigidbody rigid;
	private int currentWeapon = 0;
	private Vector3 forceVector;

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
		Vector3 movementDirection = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		movementDirection = Vector3.ClampMagnitude(movementDirection, 1f);
//		if (movementDirection != Vector3.zero) {
//			forceVector = movementDirection * enginePower;
//			if (rigid.velocity.magnitude < maxVelocity) {
//				rigid.AddForce (forceVector);
//			} else {
//				rigid.velocity = Vector3.ClampMagnitude (rigid.velocity, maxVelocity);
//				Debug.Log ("Player:Velocity Maximum: " + rigid.velocity.magnitude);
//			}
//		} else {
////			forceVector = Vector3.Lerp (rigid.velocity, Vector3.zero, 0.05f);
////			forceVector = Vector3.SmoothDamp (rigid.velocity, Vector3.zero, 0.95f,
////			Vector3 impulse = -forceVector * rigid.mass;
////			rigid.AddForce (impulse, ForceMode.Impulse);
////			= Vector3.Lerp (rigid.velocity, Vector3.zero, 0.2f);
//		}
//		forceVector = movementDirection * enginePower / maxVelocity;

		float velocity =  Mathf.Sqrt(2 * enginePower * movementDirection.magnitude * Time.fixedDeltaTime / rigid.mass); // v = sqrt(2*P*t/m) <= E = m*v^2/2  &  E = P*t
		Vector3 newVelocity =  Vector3.ClampMagnitude (movementDirection.normalized * velocity, maxVelocity);
		forceVector = (newVelocity - rigid.velocity) * rigid.mass / Time.fixedDeltaTime;
		rigid.AddForce (forceVector);



////			movement = transform.position + movement;
////            var mousePosition = Input.mousePosition;
////            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
////		transform.position = Vector2.Lerp (transform.position, movement, speed);

//		rigid.velocity = movementDirection * maxVelocity;
//		Debug.Log (Time.time + ": " + movementDirection );
//
		Vector3 min = transform.parent.TransformPoint(boundary.Min);
		Vector3 max = transform.parent.TransformPoint(boundary.Max);
		rigid.position = new Vector3 (
			Mathf.Clamp (rigid.position.x, min.x, max.x),
			0.0f,
			Mathf.Clamp (rigid.position.z, min.z, max.z)
		);

		//mass
//		Debug.Log ("Player mass: " + rigid.mass);

		//Tilt
		rigid.rotation = Quaternion.Euler (movementDirection.z * tilt * 0.5f, 0.0f, -movementDirection.x * tilt);
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
//			nextFire = Time.time + fireRate;
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
