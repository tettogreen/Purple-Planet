using UnityEngine;
using System.Collections;

public class Bullet : Destructible {

	protected Transform shooter;

	[SerializeField]
	protected int damage;
	//public int Damage {get { return damage; } }

	void Awake ()
	{
		FindShooter(transform.parent);
		transform.parent = null;
	}

//	public void SetOwner (GameObject _owner)
//	{
//		owner = _owner;
//	}

	protected void FindShooter (Transform parent)
	{
		if (parent == null) {
			return;
		} else if (parent.tag == "Player" || parent.tag == "Enemy" || parent.tag == "Neutral") {
			shooter = parent;
		} else {
			FindShooter (parent.parent);
		}
	}


}
