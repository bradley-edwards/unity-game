using UnityEngine;
using System.Collections;

public class explosionSoundAndAnimation : MonoBehaviour {
	public AudioClip explosion;
	// Use this for initialization
	void Start () {
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = explosion;
		audio.PlayOneShot (audio.clip, 0.8f);
		Invoke ("Destroy", 1);
	
	}
	void Destroy() {
		Destroy (this.gameObject);
	}
		
}
