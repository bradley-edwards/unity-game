using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour {
	private Rigidbody bullet;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		bullet = GetComponent<Rigidbody> ();
		transform.position += (transform.forward + transform.right/2);
		bullet.velocity = (transform.rotation * Vector3.forward * 50);
	}
	void Update(){
		transform.Rotate (new Vector3(30f, 10f, 30f) * Time.deltaTime * 10);
	}
	void OnTriggerEnter (Collider Other) {

		if (Other.transform.parent.tag != "fan") {
			//play sound
			//explosion animation
			Instantiate(explosion, this.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
		if (Other.transform.parent.name == "Obstacles" && Other.gameObject.tag != "fan") {
			Other.gameObject.SetActive(false);
		}
		if (Other.transform.parent.parent.name == "Obstacles" && Other.transform.parent.gameObject.tag != "fan") {
			Other.transform.parent.gameObject.SetActive(false);
		}
		if (Other.transform.parent.parent.parent.name == "Obstacles") {
			Other.transform.parent.parent.gameObject.SetActive(false);
		}
		if (Other.transform.parent.name == "FanWindCollider") {
			Other.transform.parent.gameObject.SetActive(false);
		}
	}
}