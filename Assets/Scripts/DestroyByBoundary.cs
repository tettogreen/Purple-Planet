using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
    {
       other.GetComponent<Destructible>().Destruct();
        Debug.Log (other);
    }
}
