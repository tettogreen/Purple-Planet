using UnityEngine;
using System.Collections;

public class Weapon : Destructible {

	protected Transform owner;

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

	protected void FindOwner (Transform parent)
	{
		if (parent == null) {
			return;
		} else if (parent.tag == "Player" || parent.tag == "Enemy") {
			owner = parent;
		} else {
			FindOwner (parent.parent);
		}
	}
}
