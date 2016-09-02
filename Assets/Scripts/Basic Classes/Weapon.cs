using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float speed;

	protected GameObject shooter;

	[SerializeField]
	protected int damage;
	//public int Damage {get { return damage; } }

	void Awake ()
	{
		if (transform.parent != null) {
			shooter = transform.parent.gameObject;
			transform.parent = null;
//			Collider coll = GetComponent<CapsuleCollider> ();
//			coll.enabled = true;
		}
	}
}
