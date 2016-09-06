using UnityEngine;
using System.Collections;

public class Bullet : Destructible {

	protected Transform shooter;

	[SerializeField]
	protected int damage;
	//public int Damage {get { return damage; } }

	void Start ()
	{
//		if (owner == null) {
//			FindOwner(transform.parent);
//			Collider coll = GetComponent<CapsuleCollider> ();
//			coll.enabled = true;
//		}
	}

//	public void SetOwner (GameObject _owner)
//	{
//		owner = _owner;
//	}

	protected void FindShooter (Transform parent)
	{
		if (parent == null) {
			return;
		} else if (parent.tag == "Player" || parent.tag == "Enemy") {
			shooter = parent;
		} else {
			FindShooter (parent.parent);
		}
	}
}
