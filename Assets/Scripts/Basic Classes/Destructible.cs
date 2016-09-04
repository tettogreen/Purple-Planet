using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

	public int scoreValue;
	public GameObject explosion;

	[SerializeField]
	private int health;
	private int defaultHealth;

	[SerializeField]
	private int collisionDamage = 50;
	//Seconds between each colision damage
	private const float collisionDamageRate = 1.0f;

	public int CollisionDamage 	{ get { return collisionDamage; } }

	void Awake() {
		Debug.Log(gameObject.name);
		defaultHealth = health;
	}

	void OnCollisionEnter (Collision collision)
	{
		Collider col = collision.collider;
		if (col.tag == "Player" || col.tag == "Enemy") {
			TakeDamage (col.GetComponent<Destructible>().CollisionDamage);
		}
	}

	public void OnEnable ()
	{
		health = defaultHealth;
	}

	public void TakeDamage (int damage)
	{
		health -= damage;
		Debug.Log (name + " takes" + collisionDamage + " damage." + health + " left.");
		if (health <= 0) {
			Destruct();
		}

	}


	public void Destruct ()
	{
//		Debug.Log (name + " is dead!");
		if (transform.parent != null && transform.parent.tag == "PoolObject") {
			gameObject.SetActive(false);
		} else {
			Destroy (gameObject);
		}
	}

	public void Destruct (bool withExplosion)
	{
		Destruct();
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
	}

	public IEnumerator Destruct (float delay)
	{
		yield return new WaitForSeconds(delay);
		Destruct(true);
	}

}
