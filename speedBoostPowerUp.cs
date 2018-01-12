using UnityEngine;
using System.Collections;

public class speedBoostPowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider Other) {
		if (Other.gameObject.name == "Player") {
			Other.attachedRigidbody.mass = Other.attachedRigidbody.mass / 2.5f;
			Other.attachedRigidbody.drag = Other.attachedRigidbody.drag * 10;
			Destroy(gameObject);
		}
	}
}
