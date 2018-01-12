using UnityEngine;
using System.Collections;

public class bouncePad : MonoBehaviour {
	public AudioClip[] audioClip;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.name == "Player") {
			collision.rigidbody.AddForce (0, 600 * Mathf.Sqrt(collision.rigidbody.mass), 0) ;
			PlaySound(0);
		}
	}
	void PlaySound(int clip) {
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = audioClip[clip];
		audio.PlayOneShot (audio.clip, 1f);
	}
}
