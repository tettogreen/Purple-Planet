using UnityEngine;
using System.Collections;

public class DestructibleSoundController : MonoBehaviour {
	public AudioClip shot;
	public AudioClip explosion;

	public void PlayShot () {
//		if (Time.time - previousAudioStartTime >= minPlaybackOffset) 
//		{
//			previousAudioStartTime = Time.time;
//			//AudioSource.PlayClipAtPoint (GetComponent<AudioSource> ().clip, transform.position, 0.5f);
//			GetComponent<AudioSource> ().Play();
//		}
		PlaySound(shot);
	}

	public void PlayExplosion() {
		PlaySound(explosion);
	}

	void PlaySound(AudioClip sound) {
		if (sound != null) { 
			AudioSource.PlayClipAtPoint(sound ,transform.position);
		}
	}
}
