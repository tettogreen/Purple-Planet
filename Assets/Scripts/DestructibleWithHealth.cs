using UnityEngine;
using System.Collections;

public class DestructibleWithHealth : Destructible {

	public int scoreValue;

	private int defaultHealth;

	[SerializeField]
	private int collisionDamage = 50;
	//Seconds between each colision damage

	[SerializeField]
	protected int health;
	virtual public int Health 	{ get { return health; } set { health = value; } }

	private const float collisionDamageRate = 1.0f;
	public int CollisionDamage	{ get { return collisionDamage; } }

	void Awake() {
		Debug.Log(gameObject.name);
		defaultHealth = Health;
	}

	void OnCollisionEnter (Collision collision)
	{
		Collider col = collision.collider;
		if (col.tag == "Player" || col.tag == "Enemy" || col.tag == "Neutral") {
			TakeDamage (col.GetComponent<DestructibleWithHealth>().CollisionDamage);
		}
	}

	public void OnEnable ()
	{
		Health = defaultHealth;
	}

	public void TakeDamage (int damage)
	{
		Health -= damage;
		Debug.Log (name + " takes" + collisionDamage + " damage." + health + " left.");
		if (Health <= 0) {
			Destruct(true);
		}

	}


}
