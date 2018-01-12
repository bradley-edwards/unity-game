using UnityEngine;
using System.Collections;

public class speedPad : MonoBehaviour {
	public AudioClip speedBoost;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			collision.rigidbody.AddForce(transform.forward * 200);
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = speedBoost;
			audio.Play ();
		}
	}
	void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			collision.rigidbody.AddForce(transform.forward * 100 * Mathf.Sqrt(collision.rigidbody.mass));
		}
	}
}
