using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

	public int health;
	public int scoreValue;
	public GameObject explosion;


	[SerializeField]
	private int collisionDamage = 50;
	public int CollisionDamage 	{ get { return collisionDamage; } }

	void OnCollisionEnter (Collision collision)
	{
		Collider col = collision.collider;
		if (col.tag == "Player" || col.tag == "Enemy") {
			TakeDamage (col.GetComponent<Destructible>().collisionDamage);
		}
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
		Debug.Log (name + " is dead!");
		if (transform.parent.tag == "PoolObject") {
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
