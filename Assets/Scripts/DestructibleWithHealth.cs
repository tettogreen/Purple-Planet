using UnityEngine;
using System.Collections;

public class DestructibleWithHealth : Destructible {

	public int scoreValue;

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
			TakeDamage (col.GetComponent<DestructibleWithHealth>().CollisionDamage);
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
			Destruct(true);
		}

	}


}
