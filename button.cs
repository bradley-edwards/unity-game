using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {
	public GameObject portal;
	public GameObject winPortalLocation;

	
	// Update is called once per frame
	void OnTriggerEnter (Collider Other) {
		if (Other.transform.name == "Player" || Other.transform.name == "BananaPeelComplete(Clone)") {
			Destroy (transform.parent.gameObject);
			portal.gameObject.SetActive (true);
			portal.transform.position = winPortalLocation.transform.position;
		}
	}
}
