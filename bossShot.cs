using UnityEngine;
using System.Collections;

public class bossShot : MonoBehaviour {
	private Rigidbody rb;
	public GameObject explosion;
	public GameObject Player;
	private float Timer;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = (transform.forward * 3000 * Time.deltaTime);
		Timer = 0;
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update() {
		Timer += Time.deltaTime;
		if (Timer >= 1) {
			Invoke ("Explode", 0);
		}
	}
	void OnTriggerEnter (Collider Other) {
		if (Other.gameObject.name == "Player") {
			Other.attachedRigidbody.AddExplosionForce(100,this.transform.position,5);
			Invoke ("Explode", 0);
		}
	}

	void Explode() {
		Instantiate (explosion, this.transform.position, Quaternion.identity);
		Destroy (this.gameObject);
	}
}
