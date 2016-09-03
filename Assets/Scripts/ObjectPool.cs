using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ObjectPool : MonoBehaviour {

	public GameObject pooledObject;
	public int poolSize = 20;
	public bool willGrow;

	List<GameObject> pooledObjects;


	// Use this for initialization
	void Awake ()
	{
		pooledObjects = new List<GameObject> ();
		for (int i = 0; i < poolSize; i++) {
			GameObject obj = (GameObject)Instantiate(pooledObject, gameObject.transform);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}
	
	// Update is called once per frame
	public GameObject PoolObject ()
	{
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects [i].activeInHierarchy) {
				return pooledObjects [i];
			}
		}

		if (willGrow) {
			GameObject obj = (GameObject)Instantiate(pooledObject);
			pooledObjects.Add(obj);
			return obj;
		}

		return null;
	}
}
