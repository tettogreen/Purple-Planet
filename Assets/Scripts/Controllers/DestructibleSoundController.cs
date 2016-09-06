using UnityEngine;
using System.Collections;

public class DestructibleSoundController : MonoBehaviour {
	public AudioClip explosion;

	public void PlayExplosion() {
		PlaySound(explosion);
	}

	void PlaySound(AudioClip sound) {
		if (sound != null) { 
			AudioSource.PlayClipAtPoint(sound ,transform.position);
		}
	}
}
