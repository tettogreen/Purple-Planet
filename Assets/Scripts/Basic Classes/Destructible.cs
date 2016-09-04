using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

	public GameObject explosion;
	
	//Audio
	protected DestructibleSoundController soundPlayer;

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
			soundPlayer.PlayExplosion();
		}
	} 

	public void Destruct (float delay)
	{
		StartCoroutine (DestructIn(delay));
	}

	private IEnumerator DestructIn (float time)
	{
		yield return new WaitForSeconds(time);
		Destruct(true);
	}
}
