using UnityEngine;
using System.Collections;

public class fan : MonoBehaviour {
	public AudioClip fanNoise;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.back * Time.deltaTime * 600);
	}
	void OnTriggerEnter (Collider Other) {
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = fanNoise;
		audio.Play ();
	}
	void OnTriggerStay(Collider Other) {
		if (Other.gameObject.name == "Player") {
			Other.attachedRigidbody.AddForce (transform.forward * 75 * Mathf.Sqrt(Other.attachedRigidbody.mass) /  Vector3.Magnitude((Other.gameObject.transform.position - this.transform.position)));
		}
	}
}
