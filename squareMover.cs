using UnityEngine;
using System.Collections;

public class squareMover : MonoBehaviour {
	private float time;
	// Use this for initialization
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		transform.Translate (Vector3.forward * Time.deltaTime * 2.5f);
		if (time >= 2) {
			Invoke ("Turn", 0);
		}
	}
	void Turn() {
		transform.Rotate(0, 90, 0);
		time = 0;
	}
}
