using UnityEngine;
using System.Collections;

public class bumper : MonoBehaviour {
	public AudioClip[] audioClip;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 3, 0);
	}


	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.name == "Player") {
			collision.rigidbody.AddExplosionForce(150 * Mathf.Sqrt(collision.rigidbody.mass), transform.position, 20, ((collision.transform.position.y - this.transform.position.y) * -50f));
			PlaySound (0);
		}
	}
	void PlaySound(int clip) {
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = audioClip[clip];
		audio.PlayOneShot (audio.clip, 1f);
	}
}
